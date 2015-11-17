using System.Collections.ObjectModel;
using Core.Classes;
using EvacuateSystem.Model.Classes;
using GalaSoft.MvvmLight.Command;
using ViewModel.ViewModels.Interfaces;

namespace ViewModel.ViewModels.Classes
{
    public class ListViewModel<T> : ViewModelBase, IInitializableViewModel where T : BaseEntity
    {
        protected object Context;
        private RelayCommand _addCommand;
        private RelayCommand _editCommand;
        private RelayCommand _removeCommand;
        private Repository<T> _repository;
        private ObservableCollection<T> objectsCollection;

        public ObservableCollection<T> ObjectsCollection
        {
            get { return objectsCollection; }
            set { objectsCollection = value; OnPropertyChanged("ObjectsCollection"); }
        }
        public T SelectedObject { get; set; }

        public RelayCommand AddCommand
        {
            get { return _addCommand ?? (_addCommand = new RelayCommand(AddObject)); }
        }

        public RelayCommand EditCommand
        {
            get { return _editCommand ?? (_addCommand = new RelayCommand(EditObject)); }
        }

        public RelayCommand RemoveCommand
        {
            get { return _removeCommand ?? (_removeCommand = new RelayCommand(RemoveSelected)); }
        }
        public void Initialize(object o)
        {
            _repository = new Repository<T>();
            _repository.Initialize(o);
            ObjectsCollection = new ObservableCollection<T>(_repository.GetAll());
            Context = o;
        }

        public void RemoveSelected()
        {
            if (SelectedObject != null) 
            {
                _repository.Delete(SelectedObject);
            
                ObjectsCollection.Remove(SelectedObject);
            }
            
        }

        public virtual void AddObject()
        {
            return;
        }

        public virtual void EditObject()
        {
            return;
        }

        public void ListRewind()
        {
            ObjectsCollection = new ObservableCollection<T>(_repository.GetAll());
        }
    }
}
