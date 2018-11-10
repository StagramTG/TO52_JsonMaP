using System;
using System.Windows;
using System.IO;

using JsonMap.Simulation;

namespace JsonMap
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /**
         * Text for indicator label (lblValidityIndicator)
         */
        const string VALIDITY_VALID = "Fichier valide.";
        const string VALIDITY_UNVALID = "Fichier non valide";
        const string VALIDITY_NOFILE = "Choisir un fichier JSON valide";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenChooseFileDialog(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = 
                new Microsoft.Win32.OpenFileDialog();

            openFileDialog.DefaultExt = ".json";
            openFileDialog.Filter = "JSON Files (*.json)|*.json";

            bool? result = openFileDialog.ShowDialog();
            if(result == true)
            {
                /** Show selected file path */
                inFilePath.Text = openFileDialog.FileName;

                /** Check file's validity */
                if(inFilePath.Text != string.Empty)
                {
                    StreamReader reader = new StreamReader(inFilePath.Text);
                    SimulationManager.CurrentEpisode = Newtonsoft.Json.JsonConvert.DeserializeObject<Data.Episode>(
                        reader.ReadToEnd()
                    );

                    if(SimulationManager.CurrentEpisode.Title != string.Empty && 
                        SimulationManager.CurrentEpisode.LinesCount > 0)
                    {
                        lblValidityIndicator.Content = VALIDITY_VALID;

                        /** Set Episode data in fields */
                        lblEpisodeTitle.Text = SimulationManager.CurrentEpisode.Title;
                        lblEpisodeLinesCount.Text = SimulationManager.CurrentEpisode.LinesCount.ToString();
                        lblEpisodeCharactersCount.Text = SimulationManager.CurrentEpisode.Characters.Count.ToString();
                        lblEpisodeActionsCount.Text = SimulationManager.CurrentEpisode.Actions.Count.ToString();

                        /** Enable launch sim button */
                        btnLaunchSim.IsEnabled = true;
                    }
                    else
                    {
                        lblValidityIndicator.Content = VALIDITY_UNVALID;
                        btnLaunchSim.IsEnabled = false;
                    }
                }
                else
                {
                    lblValidityIndicator.Content = VALIDITY_NOFILE;
                    btnLaunchSim.IsEnabled = false;
                }
            }
        }
    }
}
