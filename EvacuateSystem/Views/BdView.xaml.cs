using System.ComponentModel.Composition;
using EvacuateSystem.Interfaces;

namespace EvacuateSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для BdView.xaml
    /// </summary>
    [Export("BdView", typeof(IChildView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class BdView : IChildView
    {
        public BdView()
        {
            InitializeComponent();
        }
    }
}
