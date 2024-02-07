using QuinielaComunitaria.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace QuinielaComunitaria.ViewModels
{
    public class MainViewModel : BindableObject
    {
        private ObservableCollection<User> userList = [];
        public ObservableCollection<User> UserList
        {
            get => userList;
            set 
            { 
                if (userList != value)
                {
                    userList = value;
                    OnPropertyChanged(nameof(UserList));
                } 
            }
        }

        private string? addUserText = string.Empty;
        public string? AddUserText
        {
            get => addUserText;
            set
            {
                if (addUserText != value)
                {
                    addUserText = value;
                    OnPropertyChanged(nameof(AddUserText));
                }
            }
        }

        public ICommand? AddUserCommand { get; set; }

        public MainViewModel()
        {
            AddUserCommand = new Command(AddUser);
        }

        private void AddUser()
        {
            if (string.IsNullOrEmpty(AddUserText)) return;
            UserList.Add(new User {  Name = AddUserText });
            AddUserText = string.Empty;
        }
    }
}