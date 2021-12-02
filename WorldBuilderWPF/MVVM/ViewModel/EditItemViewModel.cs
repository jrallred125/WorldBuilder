using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;
using WorldBuilderWPF.Services;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class EditItemViewModel : ObservableObject
    {
        public RelayCommand SaveCommand { get; set; }

        public RelayCommand CancelCommand { get; set; }

        public RelayCommand OpenFileCommand { get; set; }

        public EditItemViewModel(ItemModel item, ItemsViewModel itemsVM, bool isNew)
        {


            if (item != null)
            {
                Name = item.Name;
                Image = item.Image;
                Type = item.Type;
                Value = item.Value;
                Weight = item.Weight;
                Description = item.Description;
                Properties = item.Properties;
            }

            SaveCommand = new RelayCommand(o =>
            {
                item.Name = Name;
                item.Image = Image;
                item.Type = Type;
                item.Value = Value;
                item.Weight = Weight;
                item.Description = Description;
                item.Properties = Properties;
                if (isNew)
                {
                    DataController.Instance.AddItem(item);
                }
                itemsVM.CurrentView = new ItemDetailsViewModel(item, itemsVM);
            });

            CancelCommand = new RelayCommand(o =>
            {
                if (isNew)
                {
                    itemsVM.CurrentView = null;
                }
                else
                {
                    itemsVM.CurrentView = new ItemDetailsViewModel(item, itemsVM);
                }
            });

            OpenFileCommand = new RelayCommand(o =>
            {
                Image = new OpenFileDialogService().OpenFileDialog();
            });

        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _image;

        public string Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged();
            }
        }

        private string _type;

        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        private string _value;

        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        private string _weight;

        public string Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                OnPropertyChanged();
            }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        private string _properties;

        public string Properties
        {
            get { return _properties; }
            set
            {
                _properties = value;
                OnPropertyChanged();
            }
        }
    }
}
