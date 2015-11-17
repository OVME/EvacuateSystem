using System.ComponentModel.Composition;
using EvacuateSystem.Model.Classes;
using Microsoft.Practices.ServiceLocation;

namespace ViewModel.ViewModels.Classes
{
    [Export(typeof(AdressViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AdressViewModel : ListViewModel<Adress>
    {
        public override void AddObject()
        {
            var viewModel = ServiceLocator.Current.GetInstance<AddAdressViewModel>();
            viewModel.Initialize(Context);
            viewModel.SetObject(new Adress(){Street = new Street(), Village = new Village()}, false);
            viewModel.ObjectSaveEvent += ListRewind;
            ViewModelManager.ViewModelShow(viewModel);
        }

        public override void EditObject()
        {
            if(SelectedObject!=null)
            { 
                var viewModel = ServiceLocator.Current.GetInstance<AddAdressViewModel>();
                viewModel.Initialize(Context);
                viewModel.SetObject(SelectedObject, true);
                viewModel.ObjectSaveEvent += ListRewind;
                ViewModelManager.ViewModelShow(viewModel);
            }
        }
    }
}
