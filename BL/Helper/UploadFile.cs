using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemo.BL.Helper
{
    public static class  UploadFile
    {
        public static string SaveFile(IFormFile FileUrl,string FolderPath)
        {
            //Get File Directory
            string FilePath = Directory.GetCurrentDirectory() + "/wwwroot/File/" + FolderPath;

            // Get File Name
            string FileName = Guid.NewGuid() + Path.GetFileName(FileUrl.FileName);

            // Merge The Directory With File Name
            string FinalPath = Path.Combine(FilePath, FileName);

            // Save Your File As Stream "Data Overtime"
            using (var Stream = new FileStream(FinalPath, FileMode.Create))
            {
                FileUrl.CopyTo(Stream);
            }

            return FileName;
        }
        public static void RemoveFile(string FolderName, string RemovedFileName)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/File/" + FolderName + RemovedFileName))
            {
                File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/File/" + FolderName + RemovedFileName);
            }

        }
    }
}
