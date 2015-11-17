using System.ComponentModel.Composition;
using EvacuateSystem.Model.Classes;
using Microsoft.Practices.ServiceLocation;

namespace ViewModel.ViewModels.Classes
{
    [Export(typeof(AutomobileViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AutomobileViewModel : ListViewModel<Automobile>
    {
        public override void AddObject()
        {
            var viewModel = ServiceLocator.Current.GetInstance<AddAutomobileViewModel>();
            viewModel.Initialize(Context);
            viewModel.SetObject(new Automobile(), false);
            viewModel.ObjectSaveEvent += ListRewind;
            ViewModelManager.ViewModelShow(viewModel);
        }

        public override void EditObject()
        {
            if (SelectedObject != null) 
            { 
                var viewModel = ServiceLocator.Current.GetInstance<AddAutomobileViewModel>();
                viewModel.Initialize(Context);
                viewModel.SetObject(SelectedObject,true);
                viewModel.ObjectSaveEvent += ListRewind;
                ViewModelManager.ViewModelShow(viewModel);
            }
        }
    }
}
