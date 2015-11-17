using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Core.Interfaces;
using EvacuateSystem.Model.Classes;
using GalaSoft.MvvmLight.Command;
using ViewModel.ViewModels.Interfaces;

namespace ViewModel.ViewModels.Classes
{
    [Export(typeof(TripViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TripViewModel : ViewModelBase, IInitializableViewModel
    {
        #region Commands

        private RelayCommand _applyCommand;
        private RelayCommand _cancelCommand;
        public RelayCommand ApplyCommand
        {
            get { return _applyCommand ?? (_applyCommand = new RelayCommand(Apply)); }
        }
        public RelayCommand CancelCommand
        {
            get { return _cancelCommand ?? (_cancelCommand = new RelayCommand(Cancel)); }
        }
        #endregion
        [Import]
        private IRepository<Trip> _tripRepository;
        [Import]
        private IRepository<Evacuated> _evacuatedRepository;
        [Import]
        private IRepository<Resettlement> _resettlementRepository;
        [Import]
        private IRepository<Passenger> _passengerRepository;

        private ObservableCollection<Trip> _tripCollection;
        private ObservableCollection<Resettlement> _resettlementCollection;
        private DateTime _date;
        private DateTime _time;
        private Trip _trip;
        private Passenger _passenger;
        private Resettlement _resettlement;
        private string _note;
        public Passenger Passenger
        {
            get { return _passenger; }
            set { _passenger = value; }
        }

        public ObservableCollection<Trip> TripCollection
        {
            get { return _tripCollection; }
            set { _tripCollection = value; }
        }

        public ObservableCollection<Resettlement> ResettlementCollection
        {
            get { return _resettlementCollection; }
            set { _resettlementCollection = value; }
        }

        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        } 

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public Trip Trip
        {
            get { return _trip; }
            set { _trip = value; }
        }

        public Resettlement Resettlement
        {
            get { return _resettlement; }
            set { _resettlement = value; }
        }

        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        public void Initialize(object o)
        {
            _tripRepository.Initialize(o);
            _resettlementRepository.Initialize(o);
            _passengerRepository.Initialize(o);
            ResettlementCollection = new ObservableCollection<Resettlement>(_resettlementRepository.GetAll());
            TripCollection = new ObservableCollection<Trip>(_tripRepository.GetAll());
            Note = "";


        }

        public void Apply()
        {
            if (Note != null && Resettlement != null && Trip != null)
            {
                _passengerRepository.Add(new Passenger() {Note = Note, Resettlement = Resettlement, Trip = Trip});
                Close();
            }
            
        }
    

        public void Cancel()
        {
            Close();
        }
    } 
}
