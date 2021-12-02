using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class ArmorDetailsViewModel: ItemDetailsViewModel
    {
        public ArmorDetailsViewModel(ArmorModel item, ItemsViewModel itemsVm): base(item, itemsVm)
        {
            if (item != null)
            {
                ArmorClass = item.ArmorClass;
            }

            EditItemCommand = new RelayCommand(o =>
            {
                itemsVm.CurrentView = new EditArmorViewModel(item, itemsVm, false);
            });

        }

        private string _armorClass;

        public string ArmorClass
        {
            get { return _armorClass; }
            set
            {
                _armorClass = value;
                OnPropertyChanged();
            }
        }

    }
}
