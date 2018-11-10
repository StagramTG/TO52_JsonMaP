using System;
using System.Windows;

using JsonMap.Simulation;

namespace JsonMap.Gui
{
    /// <summary>
    /// Logique d'interaction pour CommunicationSettingsDialog.xaml
    /// </summary>
    public partial class CommunicationSettingsDialog : Window
    {
        public CommunicationSettingsDialog()
        {
            InitializeComponent();

            Title = "Réglages : Communication";
            inHostAddress.Text = SimulationManager.HostAdress;
            inHostPort.Text = SimulationManager.HostPort;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveAndQuit(object sender, RoutedEventArgs e)
        {
            SimulationManager.HostAdress = inHostAddress.Text;
            SimulationManager.HostPort = inHostPort.Text;

            Close();
        }
    }
}
