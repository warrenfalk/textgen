using System.Collections.Generic;

namespace TextGen
{
    /// <summary>
    /// Represents one or more lines of textual output
    /// </summary>
    public abstract class Text
    {
        public static implicit operator Text(string s) => s != null ? new TextLine(s) : null;

        public abstract IEnumerable<string> Lines { get; }

        public override string ToString() => string.Join("\n", Lines);
    }
}