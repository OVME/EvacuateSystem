using System.ComponentModel.Composition;
using EvacuateSystem.Interfaces;

namespace EvacuateSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для TripView.xaml
    /// </summary>
    [Export("TripView", typeof(IChildView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class TripView : IChildView
    {
        public TripView()
        {
            InitializeComponent();
        }
    }
}
