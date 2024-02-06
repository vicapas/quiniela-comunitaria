using System.Collections.ObjectModel;

namespace QuinielaComunitaria.ViewModels
{
    public class MainViewModel : BindableObject
    {
        private ObservableCollection<string> userList = [];
        public ObservableCollection<string> UserList
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

        public MainViewModel()
        {
            UserList = [ "User 1", " User 2", "User 3", "User 4" ];
        }
    }
}