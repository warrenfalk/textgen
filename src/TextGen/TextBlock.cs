using System.Collections.Generic;
using System.Linq;
using static TextGen.Functions;

namespace TextGen
{
    /// <summary>
    /// Represents a collection of <see cref="Text">Text</see>s that can be indented
    /// </summary>
    public class TextBlock : Text
    {
        public IEnumerable<Text> Items { get; }
        public int Indent { get; }

        public TextBlock(int indent, IEnumerable<Text> items)
        {
            Indent = indent;
            Items = items;
        }

        public override IEnumerable<string> Lines => Items.SelectMany(item => item.Lines.Select(line => Indent(Indent, line)));

        public static TextBlock Create(int indent, Text item) => Create(indent, Enumerable.Repeat(item, 1));

        public static TextBlock Create(int indent, IEnumerable<Text> items) => new TextBlock(indent, items);
    }


}