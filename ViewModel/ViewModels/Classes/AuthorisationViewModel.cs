using System.ComponentModel.Composition;
using System.Linq;
using Core.Classes;
using Core.Interfaces;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using Model.Model.Classes;
using ViewModel.ViewModels.Interfaces;

namespace ViewModel.ViewModels.Classes
{
    [Export(typeof(AuthorisationViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AuthorisationViewModel : ViewModelBase, IInitializableViewModel
    {
        private object _context;
        [Import]
        private IRepository<SystemWorker> _sysWorkerRepository;
        private string _authSurname;
        private string _authPassword;
        private RelayCommand _authoriseCommand;

        public RelayCommand AuthoriseCommand
        {
            get { return _authoriseCommand ?? (_authoriseCommand = new RelayCommand(Authorize)); }
        }
        public string AuthPassword
        {
            get { return _authPassword; }
            set { _authPassword = value; }
        }
        public string AuthSurname
        {
            get { return _authSurname; }
            set { _authSurname = value; }
        }

        public AuthorisationViewModel()
        {
            
            
        }

        public void Authorize()
        {
            if (_sysWorkerRepository.GetAll()
                .Any(p => p.Cooperator.Surname == AuthSurname && p.Password == AuthPassword))
            {
                var viewModel = ServiceLocator.Current.GetInstance<StartViewModel>();
                viewModel.Initialize(_context);
                ViewModelManager.ViewModelShow(viewModel);
                Close();
            }
        }

        public void Initialize(object o)
        {
            o = new EvacuateSystemContext();
            _sysWorkerRepository.Initialize(o);
            _context = o;
        }


    }
}
