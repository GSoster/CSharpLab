namespace PhotoGallery.Model
{
    public class Media :IMedia
    {
        public string Extension { get; }
        public string Path { get; set; }
        public string FileName { get; }//this one comes from the file


        public Media (string path)
        {
            Path = path;
            FileName = System.IO.Path.GetFileName(path);
            Extension = System.IO.Path.GetExtension(path);
        }

    }
}
