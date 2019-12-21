using System.IO;
using System.Threading.Tasks;
using Plugin.FilePicker.Abstractions;
using Zafiro.Core.Files;

namespace UnoDesigner
{
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