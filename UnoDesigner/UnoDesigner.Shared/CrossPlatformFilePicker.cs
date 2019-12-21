using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Plugin.FilePicker;
using Zafiro.Core.Files;
using IFilePicker = Zafiro.Core.Files.IFilePicker;

namespace UnoDesigner
{
    public class CrossPlatformFilePicker : IFilePicker
    {
        public IObservable<ZafiroFile> Pick(string title, string[] extensions)
        {
            return Observable.FromAsync(() => CrossFilePicker.Current.PickFile())
                .Select(data => new XamFile(data));
        }

        public IObservable<ZafiroFile> PickSave(string title, KeyValuePair<string, IList<string>>[] extensions)
        {
            return Observable.Return<ZafiroFile>(null);
        }
    }
}