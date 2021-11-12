using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class LoreDetailsViewModel : ObservableObject
    {
        public RelayCommand EditCommand { get; set; }

        public RelayCommand DeleteCommand { get; set; }

        public RelayCommand ViewImageCommand { get; set; }


        private LoreModel _selectedLore;

        public LoreModel SelectedLore
        {
            get { return _selectedLore; }
            set
            {
                _selectedLore = value;
                OnPropertyChanged();
            }
        }

        public LoreViewModel LoreVM { get; set; }

        public LoreDetailsViewModel(LoreModel lore, LoreViewModel loreVm)
        {
            SelectedLore = lore;
            LoreVM = loreVm;

            if (SelectedLore != null)
            {
                Title = SelectedLore.Title;
                Type = SelectedLore.Type;
                Image = SelectedLore.Image;
                Summary = SelectedLore.Summary;
                Information = SelectedLore.Information;
            }

            EditCommand = new RelayCommand(o => 
            {
                LoreVM.CurrentView = new EditLoreViewModel(SelectedLore, LoreVM, false);
            });

            DeleteCommand = new RelayCommand(o => 
            {
                LoreVM.CurrentView = null;
                DataController.Instance.RemoveLore(SelectedLore);
                SelectedLore = null;

            });

            ViewImageCommand = new RelayCommand(o =>
            {
                var imageWindow = new ImageWindow();
                imageWindow.Show();
            });

        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
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

        private string _summary;

        public string Summary
        {
            get { return _summary; }
            set
            {
                _summary = value;
                OnPropertyChanged();
            }
        }

        private string _information;

        public string Information
        {
            get { return _information; }
            set
            {
                _information = value;
                OnPropertyChanged();
            }
        }

    }

}
