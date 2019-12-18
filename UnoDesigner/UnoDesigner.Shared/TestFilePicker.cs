using System;
using System.Collections.Generic;
using Zafiro.Core.Files;

namespace UnoDesigner
{
    public class TestFilePicker : IFilePicker
    {
        public IObservable<ZafiroFile> Pick(string title, string[] extensions)
        {
            throw new NotImplementedException();
        }

        public IObservable<ZafiroFile> PickSave(string title, KeyValuePair<string, IList<string>>[] extensions)
        {
            throw new NotImplementedException();
        }
    }
}