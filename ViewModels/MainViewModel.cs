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
        public ICommand? AppearingCommand { get; set; }

        public MainViewModel()
        {
            AddUserCommand = new Command(AddUser);
            AppearingCommand = new Command(OnAppearing);
        }

        private async void AddUser()
        {
            if (string.IsNullOrEmpty(AddUserText)) return;
            var user = await App.UserLogic.AddUser(AddUserText);
            UserList.Add(user);
            AddUserText = string.Empty;
        }

        private async void OnAppearing()
        {
            await LoadUsers();
        }

        private async Task LoadUsers()
        {
            var users = await App.UserLogic.GetUsers();
            UserList = new ObservableCollection<User>(users);
        }
    }
}