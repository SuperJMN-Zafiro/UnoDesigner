using System.IO;
using System.Threading.Tasks;
using Plugin.FilePicker.Abstractions;
using Zafiro.Core.Files;

namespace UnoDesigner.Services
{
    public class CrossPlatformFile : ZafiroFile
    {
        private readonly FileData data;

        public CrossPlatformFile(FileData data)
        {
            this.data = data;
        }

        public override Task<Stream> OpenForRead()
        {
            var stream = data.GetStream();
            return Task.FromResult(stream);
        }

        public override Task<Stream> OpenForWrite()
        {
            var stream = data.GetStream();
            return Task.FromResult(stream);
        }

        public override string Name => data.FileName;
    }
}