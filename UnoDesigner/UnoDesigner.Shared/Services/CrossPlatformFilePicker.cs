using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using Plugin.FilePicker;
using Zafiro.Core.Files;

namespace UnoDesigner.Services
{
    public class CrossPlatformFilePicker : IFilePicker
    {
        public IObservable<ZafiroFile> Pick(string title, string[] extensions)
        {
            return Observable.FromAsync(() => CrossFilePicker.Current.PickFile(extensions))
                .Select(data => new CrossPlatformFile(data));
        }

        public IObservable<ZafiroFile> PickSave(string title, KeyValuePair<string, IList<string>>[] extensions)
        {
            var allowedTypes = extensions.SelectMany(x => x.Value).ToArray();
            return Observable.FromAsync(() => CrossFilePicker.Current.PickFile(allowedTypes))
                .Select(data => new CrossPlatformFile(data));
        }
    }
}