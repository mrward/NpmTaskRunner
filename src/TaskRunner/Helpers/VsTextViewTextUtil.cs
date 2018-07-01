using System;
using System.Text;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Ide.Editor;

namespace NpmTaskRunner.Helpers
{
    internal class VsTextViewTextUtil : ITextUtil
    {
        private int _currentLineLength;
        private int _lineNumber;
        private Document _document;

        public VsTextViewTextUtil(Document document)
        {
            _document = document;
        }

        public Range CurrentLineRange
        {
            get { return new Range { LineNumber = _lineNumber, LineRange = new LineRange { Start = 0, Length = _currentLineLength } }; }
        }

        public bool Delete(Range range)
        {
            try
            {
                int offset = _document.Editor.LocationToOffset(range.LineNumber + 1, range.LineRange.Start + 1);
                _document.Editor.RemoveText(offset, range.LineRange.Length);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Insert(Range position, string text, bool addNewline)
        {
            try
            {
                int offset = _document.Editor.LocationToOffset(position.LineNumber + 1, position.LineRange.Start + 1);
                string lineEnd = (addNewline ? Environment.NewLine : string.Empty);
                _document.Editor.InsertText(offset, text +lineEnd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool TryReadLine(out string line)
        {
            int lineCount = _document.Editor.LineCount;

            if (_lineNumber == lineCount)
            {
                line = null;
                return false;
            }

            int lineNumber = _lineNumber++;
            IDocumentLine documentLine = _document.Editor.GetLine(lineNumber + 1);
            _currentLineLength = documentLine.Length;

            line = _document.Editor.GetLineText(documentLine);

            return true;
        }

        public string ReadAllText()
        {
            StringBuilder text = new StringBuilder();
            string line;
            while (TryReadLine(out line))
            {
                text.Append(line);
            }
            return text.ToString();
        }

        public void Reset()
        {
            _currentLineLength = 0;
            _lineNumber = 0;
        }

        public void FormatRange(LineRange range)
        {
            Reset();
        }
    }
}
