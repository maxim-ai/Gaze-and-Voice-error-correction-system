using System.Collections.Generic;
using EyeGaze.Engine;
using Microsoft.Office.Interop.Word;


namespace EyeGaze.TextEditor
{
    public abstract class AbstractTextEditor<T>
    {
        public event TriggerHandlerMessage sendMessageToEngine;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cursorPosition"></param>
        /// <param name="word"> after this word add the sentence</param>
        /// <param name="wordsToAdd"> the sentence to add</param>
        /// <returns></returns>
        protected virtual void CloseFile(MessageEvent m)
        {
            sendMessageToEngine(this, m);
        }
        public abstract void SetCursorPosition(Range cursorPosition);
        public abstract void ReplaceWord(T wordToChange, string newWord);
        public abstract void CloseFile();
        public abstract List<CoordinateRange> GetCursorPositionWordsInArea();
        public abstract System.Drawing.Point GetPointOfCursorPosition();
        public abstract List<CoordinateRange> GetAllWordsInArea(System.Drawing.Point position);
        public abstract void MoveCursor(System.Drawing.Point position);
        public abstract List<CoordinateRange> GetAllWordsInRange(Range range);
        public abstract List<CoordinateRange> GetRangesForAllSameWords(string word);
        public abstract void ReplaceAllWords(List<CoordinateRange> wordsToChange, string oldWord, string newWord);
        public abstract void ReplaceAllDone();
        public abstract bool fileReadOnly();
    }
}
