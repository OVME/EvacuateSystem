using System.ComponentModel.Composition;
using EvacuateSystem.Interfaces;

namespace EvacuateSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для AddCoopView.xaml
    /// </summary>
    [Export("AddCoopView", typeof(IChildView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class AddCoopView : IChildView
    {
        public AddCoopView()
        {
            InitializeComponent();
        }
    }
}
