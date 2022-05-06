namespace EducalProjectT210.Helpers
{
    public class PictureHelper
    {
        public static string UploadPicture(IFormFile PhotoUrl,IWebHostEnvironment envor)
        {
            string photoName= Guid.NewGuid().ToString() + PhotoUrl.FileName;
            string rootName = Path.Combine(envor.WebRootPath, "uploads");
            string rootPhoto = Path.Combine(rootName, photoName);
            using FileStream myStrem = new FileStream(rootPhoto, FileMode.Create);
            PhotoUrl.CopyTo(myStrem);

            return "/uploads/" + photoName;
        }
    }
}
