using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Windows;
using EvacuateSystem.ViewManager;
using Microsoft.Mef.CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;
using ViewModel.ViewModelManager;
using ViewModel.ViewModels.Classes;

namespace EvacuateSystem
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            var assembly = new AssemblyCatalog(Assembly.GetEntryAssembly());
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(assembly);
            catalog.Catalogs.Add(new DirectoryCatalog("."));
            var compositionContainer = new CompositionContainer(catalog);
            compositionContainer.ComposeParts(this);
            var locator = new MefServiceLocator(compositionContainer);
            ServiceLocator.SetLocatorProvider(()=>locator);
            ViewModelManager.ViewModelShowEvent
                += InstanceViewModelShowEvent;
            ViewModelManager.ViewModelCloseEvent += InstanceViewModelCloseEvent;
            var authViewModel = new AuthorisationViewModel();
            compositionContainer.ComposeParts(authViewModel);
            authViewModel.Initialize(new object());
            ViewModelManager.ViewModelShow(authViewModel);
        }

        private void InstanceViewModelCloseEvent(ViewModelBase viewModel)
        {
            ViewManager.ViewClose(viewModel);
        }

        [Import]
        public IViewModelManager ViewModelManager { get; set; }

        [Import]
        public IViewManager ViewManager { get; set; }

        private void InstanceViewModelShowEvent(ViewModelBase viewmodel)
        {
            ViewManager.ViewShow(viewmodel);
        }
    }
}
