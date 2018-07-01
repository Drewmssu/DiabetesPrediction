using System;
using System.Web;

namespace DiabetesPredictionApp.Helpers
{
    public static class FileHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file">File we are going to save</param>
        /// <param name="basePath">Path we where the file is going to be saved</param>
        /// <returns>The actual path where the file will be located</returns>
        public static string GetPath(this HttpPostedFileBase file, string basePath)
        {
            try
            {
                var filename = $"{Guid.NewGuid().ToString().Split('-')[1]}_{file.FileName}";
                var path = basePath + filename;
                return path;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return String.Empty;
            }
        }
    }
}
