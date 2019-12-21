﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
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

    public class XamFile : ZafiroFile
    {
        private readonly FileData data;

        public XamFile(FileData data)
        {
            this.data = data;
        }

        public override Task<Stream> OpenForRead()
        {
            var stream = data.GetStream();
            stream.Seek(0, SeekOrigin.Begin);
            return Task.FromResult(data.GetStream());
        }

        public override Task<Stream> OpenForWrite()
        {
            var stream = data.GetStream();
            stream.Seek(0, SeekOrigin.Begin);
            return Task.FromResult(data.GetStream());
        }

        public override string Name => data.FileName;
    }
}