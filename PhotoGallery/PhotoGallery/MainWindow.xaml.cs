using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;
using PhotoGallery.Model;
using PhotoGallery.Util;
using System.Windows.Controls;

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
        public Collection UnamedPhotoCollection = new Collection();

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
         * Todo: Remove the commented lines that work with PhotoCollection, that is no more needed.
         **/
        public void LoadImagesInFolder(string path)
        {
            var list = FileHandler.GetAllFilesFromPathByExtension(path, "jpg");
            foreach (var file in list)
                UnamedPhotoCollection.PhotoList.Add(new Photo(file.FullName));

            lblQuantityPicturesDisplyed.Content = "Images in current collection: " + UnamedPhotoCollection.GetCollectionSize();
            //PhotoCollection.Add(new Photo(file.FullName));
            lstvwPhotos.ItemsSource = UnamedPhotoCollection.PhotoList;               
            //lstvwPhotos.ItemsSource = PhotoCollection;
        }

        /**
         * Todo: it is necessary to set the isCurrent attribute of this image (sender) as true!
         */
        private void SetAsCurrentDisplayedImage(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Image img = (Image)sender;
            imgCurrentDisplayedImage.Source = img.Source;
            imgCurrentDisplayedImage.UpdateLayout();
            //imgCurrentImage
        }
    }
}
