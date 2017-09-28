using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;
using PhotoGallery.Model;
using PhotoGallery.Util;
namespace PhotoGallery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string DefaultDir = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        public string CurrentImageFolderPath = string.Empty;
        public List<Photo> PhotoCollection = new List<Photo>();

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

        /**
         * Todo: *.jpg está definido diretamente, os tipos de arquivos deveriam estar em uma constante declarada. 
         **/
        public void LoadImagesInFolder(string path)
        {
            var list = FileHandler.GetAllFilesFromPathByExtension(path, "jpg");
            foreach(var file in list)
                PhotoCollection.Add(new Photo(file.FullName));
           
            lstvwPhotos.ItemsSource = PhotoCollection;            
        } 

    }
}
