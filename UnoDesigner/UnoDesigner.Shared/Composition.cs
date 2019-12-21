using System.Linq;
using Designer.Core;
using Designer.Core.Persistence;
using Designer.Core.Tools;
using Designer.Domain.ViewModels;
using Grace.DependencyInjection;
using UnoDesigner.Droid.Services;
using UnoDesigner.Services;
using Zafiro.Core.Files;

namespace UnoDesigner
{
    public class Composition
    {
        private static readonly DependencyInjectionContainer Container;

        static Composition()
        {
            Container = new DependencyInjectionContainer();
            Container.Configure(registrationBlock =>
            {
                var toolType = typeof(Tool);
                var assembly = typeof(RectangleTool).Assembly;

                registrationBlock.Export(assembly.ExportedTypes
                        .Where(TypesThat.AreBasedOn<Tool>())
                        .Where(x => !x.IsAbstract))
                    .ByTypes(type => new[] { toolType });

                registrationBlock.Export<CrossPlatformFilePicker>().As<IFilePicker>().Lifestyle.Singleton();
                registrationBlock.Export<DesignContext>().As<IDesignContext>().Lifestyle.Singleton();
                registrationBlock.Export<ViewModelFactory>().As<IViewModelFactory>().Lifestyle.Singleton();
                registrationBlock.Export<ProjectStore>().As<IProjectStore>().Lifestyle.Singleton();
                registrationBlock.Export<TestServiceFactory>().As<IServiceFactory>().Lifestyle.Singleton();
                registrationBlock.Export<TestExtensionsProvider>().As<IExtensionsProvider>().Lifestyle.Singleton();
                registrationBlock.Export<ProjectMapper>().As<IProjectMapper>().Lifestyle.Singleton();
                registrationBlock.Export<ImportExtensionsViewModel>().Lifestyle.Singleton();
                registrationBlock.Export<MainViewModel>().Lifestyle.Singleton();
            });
        }

        public static MainViewModel Root => Container.Locate<Designer.Core.MainViewModel>();

        public ImportExtensionsViewModel Import => Container.Locate<ImportExtensionsViewModel>();
    }
}