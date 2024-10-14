using System.Text;

namespace AmazonWebsite.Helpers
{
    public class MyUtil
    {
        public static  string UploadImage  (IFormFile file, string folder)
        {
            try
            {
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", "Hinh", folder, file.FileName);
                using (var myfile = new FileStream(fullPath, FileMode.CreateNew))
                {
                    file.CopyTo(myfile);
                }
               return file.FileName;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
            

        }
        public static string GenerateRandomKey(int length = 5)
        {
            var pattern = 
                @"qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM!@#$%^&*()_+=";
            var stringbuilder = new StringBuilder();
            var render = new Random();
            for (int i = 0; i < length; i++)
            {
               stringbuilder.Append(pattern[render.Next(0, pattern.Length)]);
            }
            return stringbuilder.ToString();
        }
    }
}