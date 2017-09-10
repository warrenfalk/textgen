using System;
using System.Collections.Generic;
using System.Linq;

namespace TextGen
{
    /// <summary>
    /// Provides static functions that can be statically imported
    /// Overview:
    /// In general you create either Fragments or Blocks.
    /// Blocks are just the indented form of Fragments.
    /// There are also some helpful functions such as <code>ListBlock()</code> for adding lines with list separators
    /// 
    /// General usage:
    /// <code>
    /// Fragment(
    ///    $"A line here",
    ///    Block(
    ///      "And some indented lines",
    ///      "here"
    ///    ),
    ///    $"and more lines"
    /// )
    /// </code>
    /// </summary>
    public static class Functions
    {
        public static TextBlock Block(Text item) => TextBlock.Create(4, item);
        public static TextBlock Block(params Text[] items) => TextBlock.Create(4, items.Where(item => item != null));
        public static TextBlock Block(IEnumerable<Text> items) => TextBlock.Create(4, items);
        public static TextBlock Block(IEnumerable<string> items) => TextBlock.Create(4, items.Select(item => (Text)item));
        public static TextBlock Fragment(Text item) => TextBlock.Create(0, item);
        public static TextBlock Fragment(params Text[] items) => TextBlock.Create(0, items.Where(item => item != null));
        public static TextBlock Fragment(IEnumerable<Text> items) => TextBlock.Create(0, items);
        public static TextBlock Fragment(IEnumerable<string> items) => TextBlock.Create(0, items.Select(item => (Text)item));

        public static string Lines(params string[] lines) => Lines(lines.Where(line => line != null));
        public static string Lines(IEnumerable<string> lines) => string.Join("\n", lines);

        public static TextBlock ListBlock(string endSeparator, string startSeparator, IEnumerable<string> lines) {
            var last = lines.Count() - 1;
            return Fragment(lines.Select((line, i) => $"{(i != 0 ? startSeparator : "")}{line}{(i != last ? endSeparator : "")}"));
        }

        public static string Indent(int size, string text) => string.Join("", Enumerable.Repeat(" ", size)) + text;

        public static string Parens(string expression) => $"({expression})";
    }
}
