using System.ComponentModel.Composition;
using EvacuateSystem.Interfaces;

namespace EvacuateSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для CoopView.xaml
    /// </summary>
    [Export("CoopView", typeof(IChildView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class CoopView : IChildView
    {
        public CoopView()
        {
            InitializeComponent();
        }
    }
}
