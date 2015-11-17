using System.ComponentModel.Composition;
using EvacuateSystem.Interfaces;

namespace EvacuateSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для TripListView.xaml
    /// </summary>
    [Export("TripListView", typeof(IChildView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class TripListView : IChildView
    {
        public TripListView()
        {
            InitializeComponent();
        }
    }
}
