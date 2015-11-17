using System.ComponentModel.Composition;
using EvacuateSystem.Interfaces;

namespace EvacuateSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    [Export("StartView", typeof(IChildView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class StartView : IChildView
    {
        public StartView()
        {
            InitializeComponent();
        }
    }
}
