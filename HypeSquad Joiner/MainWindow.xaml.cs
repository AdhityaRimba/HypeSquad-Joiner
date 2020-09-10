using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RaidAPI.HypeSquad;
using ToastNotifications;
using ToastNotifications.Messages;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;

namespace HypeSquad_Joiner
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

        Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: Corner.TopRight,
                offsetX: 10,
                offsetY: 10);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(3),
                maximumNotificationCount: MaximumNotificationCount.FromCount(5));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });

        private void Bravery_Button_Click(object sender, RoutedEventArgs e)
        {
            string tokens = token.Text;
            Hype.GiveHypeSquad(tokens, "1");
            notifier.ShowSuccess("Success Joined Bravery HypeSquad");
        }

        private void Brilliance_Button_Click(object sender, RoutedEventArgs e)
        {
            string tokens = token.Text;
            Hype.GiveHypeSquad(tokens, "2");
            notifier.ShowSuccess("Success Joined Brilliance HypeSquad");
        }

        private void Balance_Button_Click(object sender, RoutedEventArgs e)
        {
            string tokens = token.Text;
            Hype.GiveHypeSquad(tokens, "3");
            notifier.ShowSuccess("Success Joined Balance HypeSquad");
        }
    }
}
