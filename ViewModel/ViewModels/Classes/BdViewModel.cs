using System.ComponentModel.Composition;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using ViewModel.ViewModels.Interfaces;

namespace ViewModel.ViewModels.Classes
{
    [Export(typeof(BdViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BdViewModel : ViewModelBase, IInitializableViewModel
    {
        private object _context;
        private RelayCommand _openAdressViewCommand;
        private RelayCommand _openAutomobileViewCommand;
        private RelayCommand _openTripViewCommand;
        private RelayCommand _openCoopViewCommand;
        private RelayCommand _openVacancyViewCommand;

        public RelayCommand OpenAdressViewCommand
        {
            get { return _openAdressViewCommand ?? (_openAdressViewCommand = new RelayCommand(OpenAdressView)); }
        }

        public RelayCommand OpenAutomobileViewCommand
        {
            get
            {
                return _openAutomobileViewCommand ?? (_openAutomobileViewCommand = new RelayCommand(OpenAutomobileView));
            }
        }

        public RelayCommand OpenTripViewCommand
        {
            get { return _openTripViewCommand ?? (_openTripViewCommand = new RelayCommand(OpenTripView)); }
        }

        public RelayCommand OpenCoopViewCommand
        {
            get { return _openCoopViewCommand ?? (_openCoopViewCommand = new RelayCommand(OpenCoopView)); }
        }

        public RelayCommand OpenVacancyViewCommand
        {
            get { return _openVacancyViewCommand ?? (_openVacancyViewCommand = new RelayCommand(OpenVacancyView)); }
        }
        public void Initialize(object o)
        {
            _context = o;
        }

        public void OpenAdressView()
        {
            var viewModel = ServiceLocator.Current.GetInstance<AdressViewModel>();
            viewModel.Initialize(_context);
            ViewModelManager.ViewModelShow(viewModel);
        }
        public void OpenTripView()
        {
            var viewModel = ServiceLocator.Current.GetInstance<TripListViewModel>();
            viewModel.Initialize(_context);
            ViewModelManager.ViewModelShow(viewModel);
        }
        public void OpenCoopView()
        {
            var viewModel = ServiceLocator.Current.GetInstance<CoopViewModel>();
            viewModel.Initialize(_context);
            ViewModelManager.ViewModelShow(viewModel);
        }
        public void OpenAutomobileView()
        {
            var viewModel = ServiceLocator.Current.GetInstance<AutomobileViewModel>();
            viewModel.Initialize(_context);
            ViewModelManager.ViewModelShow(viewModel);
        }

        public void OpenVacancyView()
        {
            var viewModel = ServiceLocator.Current.GetInstance<VacancyViewModel>();
            viewModel.Initialize(_context);
            ViewModelManager.ViewModelShow(viewModel);
        }

    }
}
