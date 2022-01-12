using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;
using WorldBuilderWPF.Services;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class LoreDetailsViewModel : ObservableObject
    {
        public RelayCommand EditLoreCommand { get; set; }

        public RelayCommand DeleteLoreCommand { get; set; }
        public RelayCommand ExportLoreCommand { get; set; }

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

        public LoresViewModel LoreVM { get; set; }

        public LoreDetailsViewModel(LoreModel lore, LoresViewModel loreVm)
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

            EditLoreCommand = new RelayCommand(o => 
            {
                LoreVM.CurrentView = new EditLoreViewModel(SelectedLore, LoreVM, false);
            });

            DeleteLoreCommand = new RelayCommand(o => 
            {
                LoreVM.CurrentView = null;
                DataController.Instance.RemoveLore(SelectedLore);
                SelectedLore = null;

            });

            ViewImageCommand = new RelayCommand(o =>
            {
                var imageWindow = new ImageWindow(new ImageViewModel(Image));
                imageWindow.Show();
            });

            ExportLoreCommand = new RelayCommand(o => 
            {
                ObservableCollectionEx<LoreModel> lores = new ObservableCollectionEx<LoreModel>();
                string filepath = new FileDialogService().SaveFileDialogJson();
                lores.Add(lore);
                DataController.Instance.ExportLores(lores, filepath);
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
