using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;
using WorldBuilderWPF.Services;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class EditArmorViewModel :EditItemViewModel
    {
        public EditArmorViewModel(ArmorModel item, ItemsViewModel itemsVm, bool isNew) : base(item, itemsVm, isNew)
        {
           
            if (item != null)
            {
                ArmorClass = item.ArmorClass;
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
                if (isNew)
                {
                    DataController.Instance.AddItem(item);
                }
                itemsVm.CurrentView = new ArmorDetailsViewModel(item, itemsVm);
            });

            CancelCommand = new RelayCommand(o =>
            {
                if (isNew)
                {
                    itemsVm.CurrentView = null;
                }
                else
                {
                    itemsVm.CurrentView = new ArmorDetailsViewModel(item, itemsVm);
                }
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
