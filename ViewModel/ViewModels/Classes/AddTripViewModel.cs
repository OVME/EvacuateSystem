using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Core.Classes;
using Core.Interfaces;
using EvacuateSystem.Model.Classes;
using GalaSoft.MvvmLight.Command;
using ViewModel.ViewModels.Interfaces;

namespace ViewModel.ViewModels.Classes
{
    [Export(typeof(AddTripViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AddTripViewModel : AddViewModel<Trip>, IInitializableViewModel
    {
        #region Commands
        [Import]
        private IRepository<Automobile> _automobileRepository;
        [Import]
        private IRepository<Village> _villageRepository; 
        private RelayCommand _applyCommand;
        private RelayCommand _cancelCommand;
        private ObservableCollection<Automobile> _automobiles;
        private DateTime _date;
        private DateTime _time;
        private ObservableCollection<Village> _villages; 
        public RelayCommand ApplyCommand
        {
            get { return _applyCommand ?? (_applyCommand = new RelayCommand(Apply)); }
        }
        public RelayCommand CancelCommand
        {
            get { return _cancelCommand ?? (_cancelCommand = new RelayCommand(Cancel)); }
        }

        public ObservableCollection<Automobile> Automobiles
        {
            get { return _automobiles; }
            set { _automobiles = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public ObservableCollection<Village> Villages
        {
            get { return _villages; }
            set { _villages = value; }
        }
        #endregion
        public void Initialize(object o)
        {
            MainRepository = new Repository<Trip>();
            MainRepository.Initialize(o);
            _automobileRepository.Initialize(o);
            _villageRepository.Initialize(o);
            Automobiles = new ObservableCollection<Automobile>(_automobileRepository.GetAll());
            Villages = new ObservableCollection<Village>(_villageRepository.GetAll());
            //NewObject = new Trip();
            Date = DateTime.Now;

        }
        public void Apply()
        {
            if(IsEdit==false)
            { 
                NewObject.DepartureDateTime = Date.Date + Time.TimeOfDay;
                ObjectSave();
            }
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
    }
}
