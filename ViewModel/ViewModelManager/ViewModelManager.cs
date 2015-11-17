using System.ComponentModel.Composition;
using ViewModel.ViewModels.Classes;

namespace ViewModel.ViewModelManager
{
    [Export(typeof(IViewModelManager))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ViewModelManager : IViewModelManager
    {
        

        public event ViewModelShowDelegate ViewModelShowEvent;

        public void ViewModelShow(ViewModelBase viewModel)
        {
            OnViewModelShowEvent(viewModel);
        }

        private void OnViewModelShowEvent(ViewModelBase viewModel)
        {
            var handler = ViewModelShowEvent;
            if (handler != null) handler(viewModel);
        }

       

        public event ViewModelCloseDelegate ViewModelCloseEvent;

        public void ViewModelClose(ViewModelBase viewModel)
        {
            OnViewModelCloseEvent(viewModel);
        }

        private void OnViewModelCloseEvent(ViewModelBase viewModel)
        {
            var handler = ViewModelCloseEvent;
            if (handler != null) handler(viewModel);
        }
    }
}
