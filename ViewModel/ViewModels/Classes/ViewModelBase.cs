using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Runtime.CompilerServices;
using ViewModel.ViewModelManager;

namespace ViewModel.ViewModels.Classes
{
    public class ViewModelBase : INotifyPropertyChanged
    {

        [Import]
        public IViewModelManager ViewModelManager { get; set; }

        public event EventHandler Closed;

        public bool IsClosed { get; private set; }

        public void Close()
        {
            if (IsClosed || !OnClosing()) return;
            IsClosed = true;
            OnClosed();
            ViewModelManager.ViewModelClose(this);
        }

        protected virtual bool OnClosing()
        {
            return true;
        }

        private void OnClosed()
        {
            var handler = Closed;
            if (handler != null) handler(this, EventArgs.Empty);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
