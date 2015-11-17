using ViewModel.ViewModels.Classes;

namespace EvacuateSystem.ViewManager
{
    public interface IViewManager
    {
        void ViewShow(ViewModelBase viewModel);
        void ViewClose(ViewModelBase viewModel);
    }
}
