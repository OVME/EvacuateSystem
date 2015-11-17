using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using Core.Interfaces;
using EvacuateSystem.Model.Classes;
using GalaSoft.MvvmLight.Command;
using Model.Model.Classes;
using ViewModel.ViewModels.Interfaces;

namespace ViewModel.ViewModels.Classes
{
    [Export(typeof(GetVacancyViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    class GetVacancyViewModel : ViewModelBase, IInitializableViewModel
    {

        private RelayCommand _applyCommand;
        private RelayCommand _cancelCommand;
        [Import]
        private IRepository<Vacancy> _vacancyRepository;
        [Import]
        private IRepository<Evacuated> _evacuatedRepository;
        [Import]
        private IRepository<Worker> _workerRepository;
        private ObservableCollection<Vacancy> _vacancies;
        private ObservableCollection<Evacuated> _evacuateds;
        private ObservableCollection<Village> _villages;

        private Evacuated _selectedEvacuated;
        private Village _selectedVillage;
        private Vacancy _selectedVacancy;

        public ObservableCollection<Vacancy> Vacancies
        {
            get { return _vacancies; }
            set
            {
                _vacancies = value;
                OnPropertyChanged("Vacancies");
            }
        }

        public ObservableCollection<Evacuated> Evacuateds
        {
            get { return _evacuateds; }
            set { _evacuateds = value; }
        }

        public ObservableCollection<Village> Villages
        {
            get { return _villages; }
            set { _villages = value; }
        }

        public RelayCommand ApplyCommand
        {
            get { return _applyCommand ?? (_applyCommand = new RelayCommand(Apply)); }
        }
        public RelayCommand CancelCommand
        {
            get { return _cancelCommand ?? (_cancelCommand = new RelayCommand(Cancel)); }
        }

         

        public Evacuated SelectedEvacuated
        {
            get { return _selectedEvacuated; }
            set { _selectedEvacuated = value; }
        }

        public Vacancy SelectedVacancy
        {
            get { return _selectedVacancy; }
            set { _selectedVacancy = value; }
        }

        public Village SelectedVillage
        {
            get { return _selectedVillage; }
            set
            {
                _selectedVillage = value; 
                Vacancies = new ObservableCollection<Vacancy>(_vacancyRepository.GetAll().Where(p=>p.Village.Id==_selectedVillage.Id&&p.IsOccupied==false)); 
                
            }
        }

        public void Initialize(object o)
        {
            _evacuatedRepository.Initialize(o);
            _vacancyRepository.Initialize(o);
            _workerRepository.Initialize(o);
            Evacuateds = new ObservableCollection<Evacuated>(_evacuatedRepository.GetAll());
            Vacancies = new ObservableCollection<Vacancy>(_vacancyRepository.GetAll());
            Villages = new ObservableCollection<Village>();
            foreach (var vacancy in Vacancies.Where(vacancy => vacancy.Village!=null&&vacancy.IsOccupied==false))
            {
                Villages.Add(vacancy.Village);
            }

        }

        public void Apply()
        {
            if (SelectedEvacuated != null && SelectedVacancy != null)
            {
                _selectedVacancy.IsOccupied = true;
                _workerRepository.Add(new Worker(){Evacuated = SelectedEvacuated, Vacancy = SelectedVacancy});
                Close();
            }
            
            
        }

        public void Cancel()
        {
            Close();
        }
    }
}
