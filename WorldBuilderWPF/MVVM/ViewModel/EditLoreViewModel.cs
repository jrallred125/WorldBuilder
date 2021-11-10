using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class EditLoreViewModel : ObservableObject
    {
        public RelayCommand SaveCommand { get; set; }

        public RelayCommand CancelCommand { get; set; }


        private LoreModel _selectedLore;

        public LoreModel SelectedLore
        {
            get { return _selectedLore; }
            set {
                _selectedLore = value;
                OnPropertyChanged();
            }
        }

        private bool isNewCharacter { get; set; }

        public LoreViewModel LoreVM { get; set; }

        public EditLoreViewModel(LoreModel lore, LoreViewModel loreVm, bool isNew)
        {
            SelectedLore = lore;
            LoreVM = loreVm;
            isNewCharacter = isNew;

            if (SelectedLore != null)
            {
                Title = SelectedLore.Title;
                Image = SelectedLore.Image;
                Type = SelectedLore.Type;
                Summary = SelectedLore.Summary;
                Information = SelectedLore.Information;
            }

            SaveCommand = new RelayCommand(o =>
            {
                SelectedLore.Title = Title;
                SelectedLore.Image = Image;
                SelectedLore.Type = Type;
                SelectedLore.Summary = Summary;
                SelectedLore.Information = Information;
                if (isNewCharacter)
                {
                    DataController.Instance.AddLore(SelectedLore);
                }
                LoreVM.CurrentView = new LoreDetailsViewModel(SelectedLore, LoreVM);
            });

            CancelCommand = new RelayCommand(o =>
            {
                if (isNewCharacter)
                {
                    LoreVM.CurrentView = null;
                    SelectedLore = null;
                }
                else {
                    LoreVM.CurrentView = new LoreDetailsViewModel(SelectedLore, LoreVM);
                }
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
