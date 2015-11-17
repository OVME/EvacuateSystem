using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Threading;
using EvacuateSystem.Interfaces;
using Microsoft.Practices.ServiceLocation;
using ViewModel.ViewModels.Classes;

namespace EvacuateSystem.ViewManager
{
    [Export(typeof(IViewManager))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ViewManager : IViewManager
    {
        protected static readonly DispatcherSynchronizationContext DispatcherSynchronizationContext =
            new DispatcherSynchronizationContext(Application.Current.Dispatcher);

        private readonly Dictionary<Type, IChildView> _openViewModelMapping = new Dictionary<Type, IChildView>();

        public void ViewShow(ViewModelBase viewModel)
        {
            if (_openViewModelMapping.ContainsKey(viewModel.GetType()))
            {
                ((Window) (_openViewModelMapping[viewModel.GetType()])).Activate();
                return;
            }

            Type viewModelType = viewModel.GetType();

            var childView = ServiceLocator.Current.GetInstance<IChildView>(viewModelType.Name.Replace("ViewModel", "View"));

            childView.DataContext = viewModel;
            childView.Show();
            _openViewModelMapping.Add(viewModel.GetType(), childView);
        }

        private void OnViewModelClosed(Object sender, EventArgs e)
        {
            ViewClose((ViewModelBase)sender);
        }

        public void ViewClose(ViewModelBase viewModel)
        {
            if (_openViewModelMapping.ContainsKey(viewModel.GetType()))
            {
                IChildView childView = _openViewModelMapping[viewModel.GetType()];
                DispatcherSynchronizationContext.Post(_ => childView.Close(), null);

                _openViewModelMapping.Remove(viewModel.GetType());
            }
        }
    }
}
