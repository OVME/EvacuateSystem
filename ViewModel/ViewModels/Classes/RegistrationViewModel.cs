using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Core.Interfaces;
using EvacuateSystem.Model.Classes;
using GalaSoft.MvvmLight.Command;
using Model.Model.Classes;
using ViewModel.ViewModels.Interfaces;

namespace ViewModel.ViewModels.Classes
{
    [Export(typeof(RegistrationViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RegistrationViewModel : ViewModelBase, IInitializableViewModel
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
        #region Properties

        public DateTime EndDate { get { return _endDate; } set { _endDate = value; } }
        public RecordCard NewCard { get { return _newCard; } set { _newCard = value; } }

        public ObservableCollection<DocumentType> DocumentTypesCollection
        {
            get
            {
                return _documentTypesCollection;
            }
            set
            {
                _documentTypesCollection = value;
            }
        }

        public DocumentType SelectedDocumentType
        {
            get { return _selectedDocumentType; }
            set { _selectedDocumentType = value; }
        }

        #endregion
        #region Fields
        [Import]
        private IRepository<RecordCard> _registrationRepository;
        [Import]
        private IRepository<DocumentType> _documentTypesRepository;

        private RecordCard _newCard;
        private DateTime _endDate;
        private ObservableCollection<DocumentType> _documentTypesCollection;
        private DocumentType _selectedDocumentType;
        #endregion
        #region Methods
        public void Initialize(object o)
        {
            _registrationRepository.Initialize(o);
            _documentTypesRepository.Initialize(o);
            NewCard = new RecordCard();
            NewCard.Evacuated = new Evacuated();
            NewCard.RegistrationRecord = new RegistrationRecord();
            NewCard.Evacuated.DateOfBirth = DateTime.Parse("01-01-1990");
            EndDate = DateTime.Now;
            DocumentTypesCollection = new ObservableCollection<DocumentType>(_documentTypesRepository.GetAll());
        }

        public void Apply()
        {
            NewCard.RegistrationRecord.ArrivialDateTime = DateTime.Now;
            NewCard.RegistrationRecord.DepartureDateTime = DateTime.Now;
            _registrationRepository.Add(NewCard);
            Close();
        }

        public void Cancel()
        {
            Close();
        }
        #endregion
    }
}
