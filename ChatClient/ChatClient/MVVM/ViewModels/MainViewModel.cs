using ChatClient.Core;
using ChatClient.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.MVVM.ViewModels
{
    public class MainViewModel :ObservableObject
    {

        public ObservableCollection<MessageModel> Messages { get; set; }

        public ObservableCollection<ContactModel> Contacts { get; set; }

        /* Commands */
        public RelayCommand SendCommand { get; set; }

        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                OnPropertyChanged();
            }
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    FirstMessage= false,

                });

                Message = "";
            });

            Messages.Add(new MessageModel
            {
                UserName = "Auburn",
                UserNameColor = "#E87722",
                ImageSource = "https://www.worldanvil.com/uploads/images/2a33e079cd1aac298104a430f49d0154.png",
                Message = "Hello World",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });

            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    UserName = "Auburn",
                    UserNameColor = "#E87722",
                    ImageSource = "https://www.worldanvil.com/uploads/images/2a33e079cd1aac298104a430f49d0154.png",
                    Message = $"Test {i}",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = false
                });
            }

            for (int i = 0; i < 4; i++)
            {
                Messages.Add(new MessageModel
                {
                    UserName = "Titan",
                    UserNameColor = "#00A36C",
                    ImageSource = "https://pbs.twimg.com/media/EpPjayXXIAIS-xu.jpg",
                    Message = $"Test {i}",
                    Time = DateTime.Now,
                    IsNativeOrigin = true,
                });
            }

            Messages.Add(new MessageModel
            {
                UserName = "Titan",
                UserNameColor = "#00A36C",
                ImageSource = "https://pbs.twimg.com/media/EpPjayXXIAIS-xu.jpg",
                Message = $"Last",
                Time = DateTime.Now,
                IsNativeOrigin = true,
            });

            Contacts.Add(new ContactModel
            {
                UserName = "Auburn",
                ImageSource = "https://www.worldanvil.com/uploads/images/2a33e079cd1aac298104a430f49d0154.png",
                Messages = Messages
            });
        }



    }
}
