using Core.Classes;
using EvacuateSystem.Model.Classes;

namespace ViewModel.ViewModels.Classes
{
    public delegate void ObjectSaveDelegate();
    public class AddViewModel<T> : ViewModelBase where T : BaseEntity
    {
        public bool IsEdit { get; set; }
        protected Repository<T> MainRepository;
        public T NewObject { get; set; }
        public ObjectSaveDelegate ObjectSaveEvent;

        public void ObjectSave()
        {
            MainRepository.Add(NewObject);
            var handler = ObjectSaveEvent;
            if (handler != null) handler();
        }

        public void SetObject(T be, bool ie)
        {
            NewObject = be;
            IsEdit = ie;
        }

        public void EditedObjectSave()
        {
            MainRepository.Update(NewObject);
        } 



    }
}
