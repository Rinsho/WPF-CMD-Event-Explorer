using System.Windows;
using System.Windows.Input;

namespace RoutedEventTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void CustomEventLog(object sender, RoutedEventArgs e)
        {
            UIElement f = sender as UIElement;
            string stringData = "Event: " + e.RoutedEvent + " | Source: " + e.Source + " | Sender: " + f.GetType();
            this.UserCtrl.Output.Items.Add(stringData);
        }

        public void CustomCommandLog(object sender, ExecutedRoutedEventArgs e)
        {
            UIElement f = sender as UIElement;
            string stringData = "Command: " + e.Command + " | Source: " + e.Source + " | Sender: " + f.GetType();
            this.UserCtrl.Output.Items.Add(stringData);
        }

        public void LogCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        public void LogCanExecute2(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = false;
        }
    }

    public class CustomCommands
    {
        public static readonly RoutedCommand LogCommand = new RoutedCommand("LogCommand", typeof(CustomCommands));
        public static readonly RoutedCommand LogCommand2 = new RoutedCommand("LogCommand2", typeof(CustomCommands));
    }
}

