namespace ContestManager.UI1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Регистрация маршрутов для навигации
            Routing.RegisterRoute(nameof(ParticipantDetailsPage), typeof(ParticipantDetailsPage));
        }
    }
}
