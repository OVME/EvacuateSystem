using System.ComponentModel.Composition;
using EvacuateSystem.Interfaces;

namespace EvacuateSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для AddTripView.xaml
    /// </summary>
    [Export("AddTripView", typeof(IChildView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class AddTripView : IChildView
    {
        public AddTripView()
        {
            InitializeComponent();
        }
    }
}
