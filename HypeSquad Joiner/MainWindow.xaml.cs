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
using RaidAPI.Core;
using RaidAPI.Core.Profile;
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

        public void Give_HypeSquad(string _HypeSquad, string _id)
        {
            string tokensu = token.Text;
            ClientInfos.GetInfos(tokensu);
            string nick = ClientInfos._Name;
            if (nick == null)
            {
                notifier.ShowError("Invalid Token");
            }
            else
            {
                Hype.GiveHypeSquad(tokensu, _id);
                notifier.ShowSuccess("Success, Given "+_HypeSquad+" To " + nick);
            }
        }

        private void Bravery_Button_Click(object sender, RoutedEventArgs e)
        {
            Give_HypeSquad("Bravery", "1");
        }

        private void Brilliance_Button_Click(object sender, RoutedEventArgs e)
        {
            Give_HypeSquad("Brilliance", "2");
        }

        private void Balance_Button_Click(object sender, RoutedEventArgs e)
        {
            Give_HypeSquad("Balance", "3");
        }
    }
}
