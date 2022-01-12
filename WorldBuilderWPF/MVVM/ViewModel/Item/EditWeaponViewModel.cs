using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;


namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class EditWeaponViewModel : EditItemViewModel
    {
        public EditWeaponViewModel(WeaponModel item, ItemsViewModel itemsVm, bool isNew) :base(item, itemsVm, isNew)
        {
            if (item != null)
            {
                Damage = item.Damage;
            }

            SaveCommand = new RelayCommand(o =>
            {
                item.Name = Name;
                item.Image = Image;
                item.Type = Type;
                item.Value = Value;
                item.Weight = Weight;
                item.Description = Description;
                item.Damage = Damage;
                item.Properties = Properties;
                if (isNew)
                {
                    DataController.Instance.AddItem(item);
                }
                itemsVm.CurrentView = new WeaponDetailsViewModel(item, itemsVm);
            });

            CancelCommand = new RelayCommand(o =>
            {
                if (isNew)
                {
                    itemsVm.CurrentView = null;
                }
                else
                {
                    itemsVm.CurrentView = new WeaponDetailsViewModel(item, itemsVm);
                }
            });
        }
        
        private string _damage;

        public string Damage
        {
            get { return _damage; }
            set
            {
                _damage = value;
                OnPropertyChanged();
            }
        }
    }
}
