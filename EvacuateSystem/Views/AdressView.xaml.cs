using System.ComponentModel.Composition;
using EvacuateSystem.Interfaces;

namespace EvacuateSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для AdressesView.xaml
    /// </summary>
    [Export("AdressView", typeof(IChildView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class AdressView : IChildView
    {
        public AdressView()
        {
            InitializeComponent();
        }
    }
}
