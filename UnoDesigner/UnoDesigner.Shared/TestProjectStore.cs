using System.IO;
using System.Threading.Tasks;
using Designer.Core;
using Designer.Domain.Models;

namespace UnoDesigner
{
    public class TestProjectStore : IProjectStore
    {
        public Task Save(Project project, Stream stream)
        {
            throw new System.NotImplementedException();
        }

        public Task<Project> Load(Stream stream)
        {
            throw new System.NotImplementedException();
        }
    }
}