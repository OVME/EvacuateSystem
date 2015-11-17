using System.Windows;
using ViewModel.ViewModels.Classes;

namespace EvacuateSystem.Classes
{
    public class ViewBase : Window
    {
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            if (!((ViewModelBase)DataContext).IsClosed)
            {
                e.Cancel = true;
                ((ViewModelBase)DataContext).Close();
            }
        }
    }
}
