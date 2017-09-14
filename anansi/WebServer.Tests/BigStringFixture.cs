using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebServer.Core;
using Xunit;

namespace WebServer.Tests
{
    public class BigStringFixture
    {
        [Fact]
        public void Big_string_should_always_require_a_byte_array_to_create()
        {
            var text = "Hello\r\nWorld";
            var buffer = Encoding.ASCII.GetBytes(text);
            var str = new BigString(buffer);
            Assert.Equal(buffer, str.Array);
        }


        [Fact]
        public void Big_string_should_be_able_to_return_a_native_string()
        {
            var text = "Hello\r\nWorld";
			var buffer = Encoding.ASCII.GetBytes(text);
			var str = new BigString(buffer);
			Assert.Equal(text, str.ToString());
        }

        [Theory]
        [MemberData("GetData", MemberType = typeof(TestData))]
		public void Big_string_can_be_split_based_on_byte_sequence_theory(string text, string delimiterText, string[] expectedTokens)
		{
            var delimiter = Encoding.ASCII.GetBytes(delimiterText);
			var buffer = Encoding.ASCII.GetBytes(text);

			var str = new BigString(buffer);
			var tokens = str.Split(delimiter);
			Assert.Equal(expectedTokens.Length, tokens.Length);
            for (int i = 0; i < tokens.Length; i++)
            {
                Assert.Equal(expectedTokens[i], tokens[i].ToString());
            }
        }

        [Fact]
        public void Spliting_an_already_split_big_string()
        {
            var data = Encoding.ASCII.GetBytes("a: b||c: d");
            var str = new BigString(data);
            var first = str.Split(Encoding.ASCII.GetBytes("||")).Last();
            var tokens = first.Split(Encoding.ASCII.GetBytes(": "));
            Assert.Equal("c", tokens[0].ToString());
            Assert.Equal("d", tokens[1].ToString());
        }

    }

    internal static class TestData 
    {
        public static IEnumerable<object[]> GetData
        {
            get 
            {
                yield return new object[] { "a b", " ", new[] { "a", "b" } };
                yield return new object[] { "Hello\r\nWorld", "\r\n", new[] { "Hello", "World" } };
                yield return new object[] { "Hello\r\n", "\r\n", new[] { "Hello"} };
                yield return new object[] { "Hello\n", "\r\n", new[] { "Hello\n" } };
                yield return new object[] { "a\r\n\r\n", "\r\n", new[] { "a", string.Empty } };
                yield return new object[] { "\r\n\r\n", "\r\n", new[] { string.Empty, string.Empty } };
            }
        }
    }
}
