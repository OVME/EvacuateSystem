using System.ComponentModel.Composition;
using EvacuateSystem.Interfaces;

namespace EvacuateSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для AutomobileView.xaml
    /// </summary>
    [Export("AutomobileView", typeof(IChildView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class AutomobileView : IChildView
    {
        public AutomobileView()
        {
            InitializeComponent();
        }
    }
}
