using JMXFileEditor.ViewModels;
using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace JMXFileEditor
{
    /// <summary>
    /// Interaction logic for the MainWindow
    /// </summary>
    public partial class MainWindow : Window, IWindow
    {
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            // Set view model
            DataContext = new ApplicationViewModel(this);
        }
        #endregion

        #region Interface implementation
        public string OpenFileDialog(string Title, string Filter, string InitialDirectoryPath = "")
        {
            // Build dialog to search the file path
            var fileBrowserDialog = new OpenFileDialog
            {
                Title = Title,
                Filter = Filter,
                InitialDirectory = InitialDirectoryPath
            };
            return fileBrowserDialog.ShowDialog(this) == true ? fileBrowserDialog.FileName : string.Empty;
        }
        public string SaveFileDialog(string Title, string FileName, string Filter, string InitialDirectoryPath = "")
        {
            // Build dialog to search the file path
            var fileBrowserDialog = new SaveFileDialog
            {
                Title = Title,
                FileName = FileName,
                Filter = Filter,
                InitialDirectory = InitialDirectoryPath
            };
            return fileBrowserDialog.ShowDialog(this) == true ? fileBrowserDialog.FileName : string.Empty;
        }
        public void ShowMessage(string Title, string Message)
        {
            MessageBox.Show(this, Message, Title, MessageBoxButton.OK, MessageBoxImage.Information);
        }
        #endregion
    }
}
