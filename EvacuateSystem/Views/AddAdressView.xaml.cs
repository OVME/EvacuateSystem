using System.ComponentModel.Composition;
using EvacuateSystem.Interfaces;

namespace EvacuateSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для AddAdressView.xaml
    /// </summary>
    [Export("AddAdressView", typeof(IChildView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class AddAdressView : IChildView
    {
        public AddAdressView()
        {
            InitializeComponent();
        }
    }
}
