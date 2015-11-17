using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using Core.Classes;
using Core.Interfaces;
using EvacuateSystem.Model.Classes;
using GalaSoft.MvvmLight.Command;
using ViewModel.ViewModels.Interfaces;

namespace ViewModel.ViewModels.Classes
{
    [Export(typeof(AddAutomobileViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AddAutomobileViewModel : AddViewModel<Automobile>, IInitializableViewModel
    {
        #region Commands

        private RelayCommand _applyCommand;
        private RelayCommand _cancelCommand;
        private ObservableCollection<PEPCooperator> _coopList;
        
        [Import]
        private IRepository<PEPCooperator> _coopRepository;
        public RelayCommand ApplyCommand
        {
            get { return _applyCommand ?? (_applyCommand = new RelayCommand(Apply)); }
        }
        public RelayCommand CancelCommand
        {
            get { return _cancelCommand ?? (_cancelCommand = new RelayCommand(Cancel)); }
        }


        public ObservableCollection<PEPCooperator> CoopList
        {
            get { return _coopList; }
            set { _coopList = value; }
        }

        #endregion
        public void Initialize(object o)
        {
            MainRepository = new Repository<Automobile>();
            MainRepository.Initialize(o);
            _coopRepository.Initialize(o);
            CoopList = new ObservableCollection<PEPCooperator>(_coopRepository.GetAll().Where(p => p.Role.Title == "Водитель"));
            //NewObject = new Automobile();
            

        }
        public void Apply()
        {
            if (!IsEdit)
            {
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
