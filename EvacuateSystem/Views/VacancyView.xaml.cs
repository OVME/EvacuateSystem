using System.ComponentModel.Composition;
using EvacuateSystem.Interfaces;

namespace EvacuateSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для VacancyView.xaml
    /// </summary>
    [Export("VacancyView", typeof(IChildView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class VacancyView : IChildView
    {
        public VacancyView()
        {
            InitializeComponent();
        }
    }
}
