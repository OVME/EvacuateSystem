using ViewModel.ViewModels.Classes;

namespace ViewModel.ViewModelManager
{
    public delegate void ViewModelShowDelegate(ViewModelBase viewModel);
    public delegate void ViewModelCloseDelegate(ViewModelBase viewModel);
    public interface IViewModelManager
    {
        event ViewModelShowDelegate ViewModelShowEvent;
        event ViewModelCloseDelegate ViewModelCloseEvent;
        void ViewModelShow(ViewModelBase viewModel);
        void ViewModelClose(ViewModelBase viewModel);
    }
}
