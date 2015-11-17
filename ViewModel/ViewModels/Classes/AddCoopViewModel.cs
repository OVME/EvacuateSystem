using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Core.Classes;
using Core.Interfaces;
using EvacuateSystem.Model.Classes;
using GalaSoft.MvvmLight.Command;
using ViewModel.ViewModels.Interfaces;

namespace ViewModel.ViewModels.Classes
{
    [Export(typeof(AddCoopViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AddCoopViewModel : AddViewModel<PEPCooperator>, IInitializableViewModel
    {
        #region Commands
        [Import]
        private IRepository<Role> _roleRepository; 
        private RelayCommand _applyCommand;
        private RelayCommand _cancelCommand;
        private ObservableCollection<Role> _roles; 
        public RelayCommand ApplyCommand
        {
            get { return _applyCommand ?? (_applyCommand = new RelayCommand(Apply)); }
        }
        public RelayCommand CancelCommand
        {
            get { return _cancelCommand ?? (_cancelCommand = new RelayCommand(Cancel)); }
        }

        public ObservableCollection<Role> Roles
        {
            get { return _roles; }
            set { _roles = value; }
        }
        #endregion
        public void Initialize(object o)
        {
            MainRepository = new Repository<PEPCooperator>();
            MainRepository.Initialize(o);
            _roleRepository.Initialize(o);
            //NewObject = new PEPCooperator(){Role=new Role()};
            Roles = new ObservableCollection<Role>(_roleRepository.GetAll());
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
