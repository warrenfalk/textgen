using System;
using Xunit;
using static TextGen.Functions;

namespace TextGen.Tests
{
    public class FunctionsTest
    {
        [Fact]
        public void SimpleFragment()
        {
            var fragment = Fragment(
                "one",
                "two"
            );
            var output = fragment.ToString();
            Assert.Equal("one\ntwo", output);
        }

        [Fact]
        public void NestedFragment()
        {
            var subfrag = Fragment(
                "one",
                "two"
            );
            var fragment = Fragment(
                "red",
                subfrag,
                "green"
            );
            var output = fragment.ToString();
            Assert.Equal("red\none\ntwo\ngreen", output);
        }

        [Fact]
        public void SimpleBlock()
        {
            var block = Block(
                "one",
                "two"
            );
            var fragment = Fragment(
                "red",
                block,
                "green"
            );
            var output = fragment.ToString();
            Assert.Equal("red\n    one\n    two\ngreen", output);
        }

        [Fact]
        public void NestedBlock()
        {
            var sublock = Block(
                "up",
                "down"
            );
            var block = Block(
                "one",
                sublock,
                "two"
            );
            var fragment = Fragment(
                "red",
                block,
                "green"
            );
            var output = fragment.ToString();
            Assert.Equal("red\n    one\n        up\n        down\n    two\ngreen", output);
        }

    }
}
