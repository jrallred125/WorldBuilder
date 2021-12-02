using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class EditMagicArmorViewModel : EditArmorViewModel
    {
        public EditMagicArmorViewModel(MagicArmorModel item, ItemsViewModel itemsVm, bool isNew) :base(item, itemsVm, isNew)
        {
            if (item != null)
            {
                Rarity = item.Rarity;
                Bonus = item.Bonus;
                IsCursed = item.IsCursed;
            }

            SaveCommand = new RelayCommand(o =>
            {
                item.Name = Name;
                item.Image = Image;
                item.Type = Type;
                item.Value = Value;
                item.Weight = Weight;
                item.Description = Description;
                item.ArmorClass = ArmorClass;
                item.Properties = Properties;
                item.Rarity = Rarity;
                item.Bonus = Bonus;
                item.IsCursed = IsCursed;
                if (isNew)
                {
                    DataController.Instance.AddItem(item);
                }
                itemsVm.CurrentView = new MagicArmorDetailsViewModel(item, itemsVm);
            });

            CancelCommand = new RelayCommand(o =>
            {
                if (isNew)
                {
                    itemsVm.CurrentView = null;
                }
                else
                {
                    itemsVm.CurrentView = new MagicArmorDetailsViewModel(item, itemsVm);
                }
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
