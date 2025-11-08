using System.Diagnostics;
using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI_Application
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; set; } = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TwoState_Unchecked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Unchecked");
        }

        private void TwoState_Checked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Checked");
        }
    }
}
