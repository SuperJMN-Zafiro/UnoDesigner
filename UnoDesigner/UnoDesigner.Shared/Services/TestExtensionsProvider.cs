using System;
using System.Collections.ObjectModel;
using Designer.Core;
using DynamicData;

namespace UnoDesigner.Droid.Services
{
    public class TestExtensionsProvider : IExtensionsProvider
    {
        public TestExtensionsProvider()
        {
            ObservableChangeset = new SourceCache<ImportViewModel, string>(x => x.Name).Connect();
            Extensions = new ReadOnlyObservableCollection<ImportViewModel>(new ObservableCollection<ImportViewModel>());
        }

        public IObservable<IChangeSet<ImportViewModel, string>> ObservableChangeset { get; }
        public ReadOnlyObservableCollection<ImportViewModel> Extensions { get; }
    }
}