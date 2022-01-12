using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class MagicWeaponDetailsViewModel : WeaponDetailsViewModel
    {
        public MagicWeaponDetailsViewModel(MagicWeaponModel item, ItemsViewModel itemsVm) :base(item, itemsVm)
        {
            if (item != null)
            {
                Rarity = item.Rarity;
                Bonus = item.Bonus;
                IsCursed = item.IsCursed;
            }

            EditItemCommand = new RelayCommand(o =>
            {
                itemsVm.CurrentView = new EditMagicWeaponViewModel(item, itemsVm, false);
            });
        }

        private string _rarity;
        public string Rarity
        {
            get { return _rarity; }
            set
            {
                _rarity = value;
                OnPropertyChanged();
            }
        }

        private string _bonus;
        public string Bonus
        {
            get { return _bonus; }
            set
            {
                _bonus = value;
                OnPropertyChanged();
            }
        }

        private bool _isCursed;
        public bool IsCursed
        {
            get { return _isCursed; }
            set
            {
                _isCursed = value;
                OnPropertyChanged();
            }
        }
    }
}
