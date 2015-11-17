using System.ComponentModel.Composition;
using EvacuateSystem.Interfaces;

namespace EvacuateSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для AddAutomobileView.xaml
    /// </summary>
    [Export("AddAutomobileView", typeof(IChildView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class AddAutomobileView : IChildView
    {
        public AddAutomobileView()
        {
            InitializeComponent();
        }
    }
}
