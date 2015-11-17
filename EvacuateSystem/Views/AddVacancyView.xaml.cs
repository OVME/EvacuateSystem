using System.ComponentModel.Composition;
using EvacuateSystem.Interfaces;

namespace EvacuateSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для AddVacancyView.xaml
    /// </summary>
    [Export("AddVacancyView", typeof(IChildView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class AddVacancyView : IChildView
    {
        public AddVacancyView()
        {
            InitializeComponent();
        }
    }
}
