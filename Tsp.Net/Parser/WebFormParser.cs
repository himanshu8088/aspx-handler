using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsp.Net
{
    class WebFormParser
    {
        public List<string> ParseElement(StreamReader stream)
        {
            List<string> elements = new List<string>();
            string s = "";
            while ((s = stream.ReadLine()) != null)
            {
                var unformattedToken = s.Split('<', '>');
                var tokens = unformattedToken.Where((c => c != "")).ToArray();
                elements.AddRange(tokens);
            }

            return elements;
        }

        public List<KeyValuePair<string, string>> ParseAttributes(string attrib)
        {
            List<KeyValuePair<string, string>> attributes = new List<KeyValuePair<string, string>>();
            try
            {                
                attrib = attrib.Substring(attrib.IndexOf(' '));
                var pairs = attrib.Split(' ');
                foreach (string pair in pairs)
                {
                    var unformattedToken = pair.Split(':');
                    var token = unformattedToken.Where((c => c != "")).ToArray();
                    if(token.Length>0)
                    attributes.Add(new KeyValuePair<string, string>(token[0], token[1]));
                }
            }catch(Exception e)
            {

            }
            
            return attributes;
        }
    }
}
