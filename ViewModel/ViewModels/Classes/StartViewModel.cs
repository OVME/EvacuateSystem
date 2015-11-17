using System.ComponentModel.Composition;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using ViewModel.ViewModels.Interfaces;

namespace ViewModel.ViewModels.Classes
{
    [Export(typeof(StartViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StartViewModel : ViewModelBase, IInitializableViewModel
    {
        #region Commands

        private RelayCommand _openRegistrationViewCommand;
        private RelayCommand _openPlacementViewCommand;
        private RelayCommand _openTripViewCommand;
        private RelayCommand _openBdViewCommand;
        private RelayCommand _openGetVacancyViewCommand;
        public RelayCommand OpenRegistrationViewCommand
        {
            get
            {
                return _openRegistrationViewCommand ??
                       (_openRegistrationViewCommand = new RelayCommand(OpenRegistrationView));
            }
        }

        public RelayCommand OpenPlacementViewCommand
        {
            get
            {
                return _openPlacementViewCommand ??
                       (_openRegistrationViewCommand = new RelayCommand(OpenPlacementView));
            }
        }

        public RelayCommand OpenTripViewCommand
        {
            get
            {
                return _openTripViewCommand ??
                       (_openTripViewCommand = new RelayCommand(OpenTripView));
            }
        }
        public RelayCommand OpenBdViewCommand
        {
            get
            {
                return _openBdViewCommand ??
                       (_openBdViewCommand = new RelayCommand(OpenBdView));
            }
        }

        public RelayCommand OpenGetVacancyViewCommand
        {
            get
            {
                return _openGetVacancyViewCommand ?? (_openGetVacancyViewCommand = new RelayCommand(OpenGetVacancyView));
            }
        }
        #endregion
        #region Properties
        
        #endregion
        #region Fields
        private object _context { get; set; }
        #endregion
        #region Methods

        public void Initialize(object o)
        {
            _context = o;
        }

        public void OpenRegistrationView()
        {
            var viewModel = ServiceLocator.Current.GetInstance<RegistrationViewModel>(); 
            viewModel.Initialize(_context);
            ViewModelManager.ViewModelShow(viewModel);
            
        }

        public void OpenPlacementView()
        {
            var viewModel = ServiceLocator.Current.GetInstance<PlacementViewModel>();
            viewModel.Initialize(_context);
            ViewModelManager.ViewModelShow(viewModel);
        }

        public void OpenTripView()
        {
            var viewModel = ServiceLocator.Current.GetInstance<TripViewModel>();
            viewModel.Initialize(_context);
            ViewModelManager.ViewModelShow(viewModel);
        }

        public void OpenBdView()
        {
            var viewModel = ServiceLocator.Current.GetInstance<BdViewModel>();
            viewModel.Initialize(_context);
            ViewModelManager.ViewModelShow(viewModel);
        }

        public void OpenGetVacancyView()
        {
            var viewModel = ServiceLocator.Current.GetInstance<GetVacancyViewModel>();
            viewModel.Initialize(_context);
            ViewModelManager.ViewModelShow(viewModel);
        }
        
        #endregion
        #region Constructors
        public StartViewModel()
        {
            //_context = new EvacuateSystemContext();
        }

        #endregion
    }
}
