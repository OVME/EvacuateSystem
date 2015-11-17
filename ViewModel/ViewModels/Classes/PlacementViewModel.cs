using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using Core.Classes;
using Core.Interfaces;
using EvacuateSystem.Model.Classes;
using GalaSoft.MvvmLight.Command;
using ViewModel.ViewModels.Interfaces;

namespace ViewModel.ViewModels.Classes
{
    [Export(typeof(PlacementViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    class PlacementViewModel : ViewModelBase, IInitializableViewModel
    {
        #region fields
        [Import]
        private IRepository<Resettlement> _placementRepository;
        [Import]
        private IRepository<Evacuated> _evacuatedRepository;
        [Import]
        private IRepository<Adress> _adressRepository;
        [Import]
        private IRepository<Village> _villageRepository;
        [Import]
        private IRepository<Street> _streetRepository;
        [Import]
        private IRepository<RecordCard> _cardRepository;
        [Import]
        private IRepository<RegistrationRecord> _registrationRepository;

        private ResettlementDocumentMaker _maker;
        private ObservableCollection<Evacuated> _evacuateds;
        private ObservableCollection<Adress> _adresses;
        private Evacuated _evacuated;
        private Resettlement _newResettlement;
        private Adress _adress;
        private string _note;
        #endregion
        #region properties

        public Evacuated Evacuated
        {
            get { return _evacuated; }
            set { _evacuated = value; }
        }

        public Adress Adress
        {
            get { return _adress; }
            set { _adress = value; }
        }

        public ObservableCollection<Adress> Adresses
        {
            get { return _adresses; }
            set { _adresses = value; }
        }

        public ObservableCollection<Evacuated> Evacuateds
        {
            get { return _evacuateds; }
            set { _evacuateds = value; }
        }

        public Resettlement NewResettlement
        {
            get { return _newResettlement; }
            set { _newResettlement = value; }
        }

        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        #endregion
        #region commands
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
        public void Initialize(object o)
        {
            _placementRepository.Initialize(o);
            _evacuatedRepository.Initialize(o);
            _adressRepository.Initialize(o);
            _villageRepository.Initialize(o);
            _streetRepository.Initialize(o);
            _cardRepository.Initialize(o);
            Adresses = new ObservableCollection<Adress>(_adressRepository.GetAll());
            Evacuateds = new ObservableCollection<Evacuated>(_evacuatedRepository.GetAll());
            Note = "";
            NewResettlement = new Resettlement();
            _maker = new ResettlementDocumentMaker(ConfigurationManager.AppSettings.Get("ResetlementTemplatePath"));
        }

        
        public void Apply()
        {
            if (Evacuated != null && Adress != null && Note != null)
            {
                var card = _cardRepository.GetAll().First(p => p.Evacuated.Id == Evacuated.Id);
                var record = card.RegistrationRecord;
                NewResettlement.RegistrationRecord = record;
                NewResettlement.Adress = Adress;
                NewResettlement.Note = Note;
                _placementRepository.Add(NewResettlement);
                _maker.MakeResettlementDocument(Evacuated, Adress, ConfigurationManager.AppSettings.Get("ResetlementNewFilePath") + Evacuated.Surname + " " + Evacuated.Name + " " + Evacuated.Patronomic + " " + Evacuated.DateOfBirth.ToString("d") + ".docx");

                /*try
                {
                    _maker.SaveTo(ConfigurationManager.AppSettings.Get("ResetlementNewFilePath"+Evacuated.Surname+" "+Evacuated.Name+" "+Evacuated.Patronomic+" "+Evacuated.DateOfBirth.ToString("d")+".docx"));
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }*/
                
                Close();

            }
            
            
        }

        public void Cancel()
        {
            Close();
        }
    }
}
