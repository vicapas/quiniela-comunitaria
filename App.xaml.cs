using QuinielaComunitaria.Logic;

namespace QuinielaComunitaria
{
    public partial class App : Application
    {
        public static UserLogic UserLogic = new();

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
