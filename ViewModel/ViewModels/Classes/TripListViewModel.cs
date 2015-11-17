using System;
using System.ComponentModel.Composition;
using EvacuateSystem.Model.Classes;
using Microsoft.Practices.ServiceLocation;

namespace ViewModel.ViewModels.Classes
{
    [Export(typeof(TripListViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TripListViewModel : ListViewModel<Trip>
    {
        public override void AddObject()
        {
            var viewModel = ServiceLocator.Current.GetInstance<AddTripViewModel>();
            viewModel.Initialize(Context);
            viewModel.SetObject(new Trip(){Automobile = new Automobile(), Village = new Village(), DepartureDateTime = DateTime.Now}, false);
            viewModel.ObjectSaveEvent += ListRewind;
            ViewModelManager.ViewModelShow(viewModel);
        }

        public override void EditObject()
        {
            if (SelectedObject != null)
            {
                var viewModel = ServiceLocator.Current.GetInstance<AddTripViewModel>();
                viewModel.Initialize(Context);
                viewModel.SetObject(SelectedObject, true);
                viewModel.ObjectSaveEvent += ListRewind;
                ViewModelManager.ViewModelShow(viewModel);
            }
            
        }
    }
}
