using System.ComponentModel.Composition;
using EvacuateSystem.Model.Classes;
using Microsoft.Practices.ServiceLocation;

namespace ViewModel.ViewModels.Classes
{
    [Export(typeof(CoopViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CoopViewModel : ListViewModel<PEPCooperator>
    {
        public override void AddObject()
        {
            var viewModel = ServiceLocator.Current.GetInstance<AddCoopViewModel>();
            viewModel.Initialize(Context);
            viewModel.SetObject(new PEPCooperator(), false);
            viewModel.ObjectSaveEvent += ListRewind;
            ViewModelManager.ViewModelShow(viewModel);
        }

        public override void EditObject()
        {
            if(SelectedObject!=null)
            { 
                var viewModel = ServiceLocator.Current.GetInstance<AddCoopViewModel>();
                viewModel.Initialize(Context);
                viewModel.SetObject(SelectedObject,true);
                viewModel.ObjectSaveEvent += ListRewind;
                ViewModelManager.ViewModelShow(viewModel);
            }
        }
    }
}
