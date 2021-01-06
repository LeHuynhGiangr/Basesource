using System;
using System.IO;

namespace Utilities
{
    static public class BytesToFileConverter
    {
        public static string BytesToImageFile(byte[] bytes, string fileName, string rootDir, string subDir="")
        {
            //host static image
            //Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            //string nameImage = unixTimestamp.ToString() + "." + imageUri.FileName.Split('.')[1];

            //string filePath = $"{webRootPath}\\{dirFile}";
            //string filePath = destination;
            try
            {
                string absolutePath = rootDir;
                string fileNameWithExtension = fileName + ".png";
                if (subDir != String.Empty)
                    absolutePath += (SystemConstants.DIRECTORY_SEPARATOR_CHAR + subDir);

                if (!Directory.Exists(absolutePath))
                {
                    var separator = Path.DirectorySeparatorChar;
                    Directory.CreateDirectory(absolutePath);
                }

                //File.WriteAllBytes(destination + "\\" + fileName, bytes);

                using (FileStream fileStream = System.IO.File.Create(absolutePath + SystemConstants.DIRECTORY_SEPARATOR_CHAR + fileNameWithExtension))
                {
                    //bytes.CopyTo(fileStream);
                    fileStream.Write(bytes, 0, bytes.Length);
                    fileStream.Flush();
                }

                return subDir+ "/" + fileNameWithExtension;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
