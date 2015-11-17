using System.ComponentModel.Composition;
using EvacuateSystem.Interfaces;

namespace EvacuateSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для PlacementView.xaml
    /// </summary>
    [Export("PlacementView",typeof(IChildView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class PlacementView : IChildView
    {
        public PlacementView()
        {
            InitializeComponent();
        }
    }
}
