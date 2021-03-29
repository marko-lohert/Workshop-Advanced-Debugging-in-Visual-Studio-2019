using System.Collections.Generic;
using System.Windows;

namespace FindInFilesRegex
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

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string folder = txtStartFolder.Text;
            string regex = txtRegex.Text;

            Analyzer analyzer = new();
            List<File> listFiles = await analyzer.FindInFilesAsync(folder, regex);

            listAll.ItemsSource = listFiles;
        }
    }
}
