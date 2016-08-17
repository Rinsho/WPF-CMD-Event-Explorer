using System.Windows;
using System.Windows.Controls;

namespace RoutedEventTest
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            //this.CustomClick += StartCustomEvent;
            //this.AddHandler(Button.ClickEvent, new RoutedEventHandler(StartCustomEvent));
        }

        public static readonly RoutedEvent CustomClickEvent = EventManager.RegisterRoutedEvent("CustomClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UserControl1));

        public event RoutedEventHandler CustomClick
        {
            add { AddHandler(CustomClickEvent, value); }
            remove { AddHandler(CustomClickEvent, value); }
        }

        public void StartCustomEvent(object sender, RoutedEventArgs e)
        {
            (e.OriginalSource as UIElement).RaiseEvent(new RoutedEventArgs(CustomClickEvent));
        }

        public void EventLog(object sender, RoutedEventArgs e)
        {
            UIElement f = sender as UIElement;
            string stringData = "#Event: " + e.RoutedEvent + " | Source: " + e.Source + " | Sender: " + f.GetType();
            this.Output.Items.Add(stringData);
        }

        public void SuppressClick(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }
    }
}
