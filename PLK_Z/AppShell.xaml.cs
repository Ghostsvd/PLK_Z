using NumbersApi.Views;

using Xamarin.Forms;

namespace NumbersApi
{

    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(NoteAddingPage), typeof(NoteAddingPage));
        }
    }
}