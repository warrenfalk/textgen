using System.Collections.Generic;
using System.Linq;

namespace TextGen
{
    /// <summary>
    /// Represents a single line of text
    /// </summary>
    public class TextLine : Text
    {
        public string Line { get; }

        public TextLine(string line)
        {
            Line = line;
        }

        public override IEnumerable<string> Lines => Enumerable.Repeat(Line, 1);
    }
}