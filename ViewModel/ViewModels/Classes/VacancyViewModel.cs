using System.ComponentModel.Composition;
using Microsoft.Practices.ServiceLocation;
using Model.Model.Classes;

namespace ViewModel.ViewModels.Classes
{
    [Export(typeof(VacancyViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class VacancyViewModel : ListViewModel<Vacancy>
    {
        public override void AddObject()
        {
            var viewModel = ServiceLocator.Current.GetInstance<AddVacancyViewModel>();
            viewModel.Initialize(Context);
            viewModel.SetObject(new Vacancy(){Profession = new Profession()}, false);
            viewModel.ObjectSaveEvent += ListRewind;
            ViewModelManager.ViewModelShow(viewModel);
        }

        public override void EditObject()
        {
            if (SelectedObject != null)
            {
                var viewModel = ServiceLocator.Current.GetInstance<AddVacancyViewModel>();
                viewModel.Initialize(Context);
                viewModel.SetObject(SelectedObject, true);
                viewModel.ObjectSaveEvent += ListRewind;
                ViewModelManager.ViewModelShow(viewModel);
            }
        }
    }
}
