using System.ComponentModel.Composition;
using System.Linq;
using Core.Classes;
using Core.Interfaces;
using EvacuateSystem.Model.Classes;
using GalaSoft.MvvmLight.Command;
using ViewModel.ViewModels.Interfaces;

namespace ViewModel.ViewModels.Classes
{
    [Export(typeof(AddAdressViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AddAdressViewModel : AddViewModel<Adress>, IInitializableViewModel
    {
        #region Commands

        private RelayCommand _applyCommand;
        private RelayCommand _cancelCommand;
        [Import]
        private IRepository<Street> _streetRepository;
        [Import]
        private IRepository<Village> _villageRepository; 
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
            MainRepository = new Repository<Adress>();
            MainRepository.Initialize(o);
            _streetRepository.Initialize(o);
            _villageRepository.Initialize(o);
            //NewObject = new Adress {Street = new Street(), Village = new Village()};
        }
        public void Apply()
        {
            if (!IsEdit)
            {
                if (_streetRepository.GetAll().Any(p => p.Title == NewObject.Street.Title))
                    NewObject.Street = _streetRepository.GetAll().First(p => p.Title == NewObject.Street.Title);
                if (_villageRepository.GetAll().Any(p => p.Name == NewObject.Village.Name))
                    NewObject.Village = _villageRepository.GetAll().First(p => p.Name == NewObject.Village.Name);
                if (NewObject.Street.Village == null)
                    NewObject.Street.Village = NewObject.Village;
                ObjectSave();
            }
            else
            {
                if (_streetRepository.GetAll().Any(p => p.Title == NewObject.Street.Title))
                    NewObject.Street = _streetRepository.GetAll().First(p => p.Title == NewObject.Street.Title);
                if (_villageRepository.GetAll().Any(p => p.Name == NewObject.Village.Name))
                    NewObject.Village = _villageRepository.GetAll().First(p => p.Name == NewObject.Village.Name);
                if (NewObject.Street.Village == null)
                    NewObject.Street.Village = NewObject.Village;
                EditedObjectSave();
            }
            
                
            
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
