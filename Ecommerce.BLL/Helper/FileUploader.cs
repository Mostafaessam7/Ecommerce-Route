using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Helper
{
    public static class FileUploader
    {
        public static string UploadFile(string Filepath, IFormFile file)
        {
            try
            {
                //    1 )  Get Directory
                string FolderPath = Directory.GetCurrentDirectory() + "/wwwroot/" + Filepath;

                //  2)  // Get File Name
                string FileName = Guid.NewGuid() + Path.GetFileName(file.FileName);

                //   3)  // Merge Path with File Name
                string FinalPath = Path.Combine(FolderPath, FileName);

                //   4)  // Save File As Streams "Data Overtime"
                using (var Stream = new FileStream(FinalPath, FileMode.Create))
                {
                    file.CopyTo(Stream);
                }
                return FileName;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        public static void DeleteFile(string FolderPath, string fileName)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/" + FolderPath + fileName))
            {
                File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/" + FolderPath + fileName);
            }
        }
    }
}
