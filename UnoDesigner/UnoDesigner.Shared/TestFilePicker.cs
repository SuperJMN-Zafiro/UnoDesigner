using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Zafiro.Core.Files;

namespace UnoDesigner
{
    public class TestFilePicker : IFilePicker
    {
        public IObservable<ZafiroFile> Pick(string title, string[] extensions)
        {
            return Observable.Return<ZafiroFile>(null);
        }

        public IObservable<ZafiroFile> PickSave(string title, KeyValuePair<string, IList<string>>[] extensions)
        {
            return Observable.Return<ZafiroFile>(null);
        }
    }
}