using System.ComponentModel.Composition;
using EvacuateSystem.Interfaces;

namespace EvacuateSystem.Views
{
    /// <summary>
    /// Логика взаимодействия для GetVacancyView.xaml
    /// </summary>
    [Export("GetVacancyView",typeof(IChildView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class GetVacancyView : IChildView
    {
        public GetVacancyView()
        {
            InitializeComponent();
        }
    }
}
