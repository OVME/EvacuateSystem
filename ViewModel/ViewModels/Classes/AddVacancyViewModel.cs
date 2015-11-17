using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using Core.Classes;
using Core.Interfaces;
using EvacuateSystem.Model.Classes;
using GalaSoft.MvvmLight.Command;
using Model.Model.Classes;
using ViewModel.ViewModels.Interfaces;

namespace ViewModel.ViewModels.Classes
{
    [Export(typeof(AddVacancyViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AddVacancyViewModel : AddViewModel<Vacancy>, IInitializableViewModel
    {
        [Import]
        private IRepository<Profession> _professionRepository;
        [Import]
        private IRepository<Village> _villageRepository;  
        private RelayCommand _applyCommand;
        private RelayCommand _cancelCommand;
        private ObservableCollection<Village> _villages;

        
        public RelayCommand ApplyCommand
        {
            get { return _applyCommand ?? (_applyCommand = new RelayCommand(Apply)); }
        }
        public RelayCommand CancelCommand
        {
            get { return _cancelCommand ?? (_cancelCommand = new RelayCommand(Cancel)); }
        }

        public ObservableCollection<Village> Villages
        {
            get { return _villages; }
            set { _villages = value; }
        }

        public void Apply()
        {
            if (!_professionRepository.GetAll().Any(p => p.Title == NewObject.Profession.Title))
            {
                _professionRepository.Add(NewObject.Profession);
            }
            if(!IsEdit)
            ObjectSave();
            else
                EditedObjectSave();
            Close();
        }

        public void Cancel()
        {
            if (IsEdit)
            {
                NewObject = MainRepository.Get(NewObject.Id);
            }
            Close();
        }

        public void Initialize(object o)
        {
            MainRepository = new Repository<Vacancy>();
            MainRepository.Initialize(o);
            _professionRepository.Initialize(o);
            _villageRepository.Initialize(o);
            Villages = new ObservableCollection<Village>(_villageRepository.GetAll());
            
        }

       
    }
}
