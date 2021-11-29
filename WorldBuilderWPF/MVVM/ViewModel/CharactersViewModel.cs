﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class CharactersViewModel : ObservableObject
    {
        private ObservableCollection<CharacterModel> _characters;

        public ObservableCollection<CharacterModel> Characters
        {
            get { return _characters; }
            set
            {
                _characters = value;
                OnPropertyChanged();
            }
        }


        public RelayCommand SearchCommand { get; set; }

        public RelayCommand NewCharacterCommand { get; set; }




        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        private string _searchProp;

        public string SearchProp
        {
            get { return _searchProp; }
            set
            {
                _searchProp = value;
                OnPropertyChanged();
            }
        }

        private CharacterModel _selectedCharacter;
        public CharacterModel SelectedCharacter
        {
            get { return _selectedCharacter; }
            set
            {
                _selectedCharacter = value;
                OnPropertyChanged();
                if (_selectedCharacter != null)
                {
                    OpenCharacterDetails();
                }
            }
        }

        private void OpenCharacterDetails()
        {
            CurrentView = new CharacterDetailsViewModel(SelectedCharacter, this);
        }

        public CharactersViewModel()
        {
            Characters = DataController.Instance.Characters;

            SearchCommand = new RelayCommand(o =>
            {
                Characters = DataController.Instance.SearchCharacters(SearchProp);
            });

            NewCharacterCommand = new RelayCommand(o =>
            {
                CharacterModel character = new CharacterModel();
                CurrentView = new EditCharacterViewModel(character, this, true);
            });

        }
    }
}