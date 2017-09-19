using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Collections;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;

namespace PhotoGallery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string DefaultDir = @"C:\";
        public string CurrentImageFolderPath = string.Empty;
        public List<Photo> PhotoCollection;

        public MainWindow()
        {
            InitializeComponent();
            btnSearchImageFolder.Click += SearchImageFolder;
        }

        private void SearchImageFolder(object sender, RoutedEventArgs e)
        {
            var dlg = new CommonOpenFileDialog();
            dlg.Title = "Search Photos";
            dlg.IsFolderPicker = true;
            dlg.InitialDirectory = DefaultDir;

            dlg.AddToMostRecentlyUsedList = false;
            dlg.AllowNonFileSystemItems = false;
            dlg.DefaultDirectory = DefaultDir;
            dlg.EnsureFileExists = true;
            dlg.EnsurePathExists = true;
            dlg.EnsureReadOnly = false;
            dlg.EnsureValidNames = true;
            dlg.Multiselect = false;
            dlg.ShowPlacesList = true;

            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                var folder = dlg.FileName;
                CurrentImageFolderPath = folder.ToString();
                //Todo: remover linha abaixo.
                MainWindow.GetWindow(this).Title = folder.ToString();//debug only
                LoadImagesInFolder(CurrentImageFolderPath);
            }
        }


        public void LoadImagesInFolder(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            foreach (var p in dirInfo.GetFiles("*.jpg"))
                lstvwPhotos.Items.Add(p.FullName);

            lstvwPhotos.UpdateLayout();
                    //MessageBox.Show(p.FullName);
                    //PhotoCollection.Add(new Photo(p.FullName));

            //fulfil listview            
            //lstvwPhotos.Items.Add("valores");
        } 

    }
}
