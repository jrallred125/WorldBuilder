using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class WeaponDetailsViewModel :ItemDetailsViewModel
    {
        public WeaponDetailsViewModel(WeaponModel item, ItemsViewModel itemsVm) :base(item, itemsVm)
        {
            if (item != null)
            {
                Damage = item.Damage;
            }

            EditItemCommand = new RelayCommand(o =>
            {
                itemsVm.CurrentView = new EditWeaponViewModel(item, itemsVm, false);
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
