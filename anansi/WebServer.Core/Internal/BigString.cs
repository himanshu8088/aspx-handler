using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer.Core
{
    public class BigString
    {
        public BigString(byte[] buffer) : this(buffer, 0, buffer.Length)
        {
        }

        private BigString(byte[] buffer, int offset, int count)
        {
            _segment = new ArraySegment<byte>(buffer, offset, count);
        }

        private readonly ArraySegment<byte> _segment;

        public byte[] Array { get { return _segment.Array; } }

        public override string ToString()
        {
            return Encoding.ASCII.GetString(_segment.Array, _segment.Offset, _segment.Count);
        }

        public BigString[] Split(byte[] delimiter)
        {
            List<BigString> tokens = new List<BigString>();
            int start = 0;
            int delIndex = 0;
            bool matchStarted = false;
            bool isCopied = true;
            int i = 0;
            foreach(var current in _segment)    
            {
                isCopied = false;
                var del = delimiter[delIndex];
                var isMatch = current == del;
                var isDelimiterFullyMatched = isMatch == true && delIndex == delimiter.Length - 1;

                if (isMatch == false )
                {
                    matchStarted = false;
                    delIndex = 0;
                }
                else 
                {
                    matchStarted = matchStarted || true;
                    if (isDelimiterFullyMatched == true)
                    {
                        var count = (i - delimiter.Length + 1)-start;
                        tokens.Add(new BigString(_segment.Array, _segment.Offset + start, count));
                        // Reset all flags
                        isCopied = true;
                        start = i + 1;
                        matchStarted = false;
                        delIndex = 0;
                    }
                    else
                        delIndex++;
                }
                i++;
            }
            if (isCopied == false)
            {
                var startIndex = start + _segment.Offset;
                var lastIndex = (_segment.Offset + _segment.Count) - 1; 
                var count =  lastIndex - startIndex + 1;
                tokens.Add(new BigString(_segment.Array, startIndex, count));
            }
            return tokens.ToArray();
        }
    }
}
