/*
 * 
 * author: Le Huynh Giang
 */
using System.IO;

namespace Utilities
{
    public static class Base64Handler
    {
        //syntax of uri: data:[<media type>][;base64],<data>
        private static readonly byte[] JPG_SIGNATURE = { 0xff, 0xd8, 0xff};
        private static readonly byte[] PNG_SIGNATURE = { 0x89, 0x50, 0x4e, 0x47, 0x0d, 0x0a, 0x1a, 0x0a};//portable network graphics format
        private enum ImageFormat
        {
            jpg,
            png
        }
        public static byte[] GetImageBase64Byte(string fileName="")
        {
            try
            {
                string l_absoluteFilePath = System.IO.Path.GetFullPath(".\\..\\Utilities\\Images\\" + fileName);
                FileStream l_fileStream = new FileStream(l_absoluteFilePath, FileMode.Open, FileAccess.Read);
                BinaryReader l_binaryReader = new BinaryReader(l_fileStream, System.Text.Encoding.UTF8);
                byte[] l_imageBytes = l_binaryReader.ReadBytes((int)l_fileStream.Length);
                l_fileStream.Close();
                l_binaryReader.Close();
                return l_imageBytes;
            }
            catch(FileNotFoundException fileNotFoundException)
            {
                throw new System.Exception(message: fileNotFoundException.Message + "|" + "get uri failure");
            }
            catch(System.Exception e)
            {
                throw new System.Exception(message: e.Message);
            }
        }

        public static string GetImageBase64String(string fileName = "")
        {
            try
            {
                string l_absoluteFilePath = System.IO.Path.GetFullPath(".\\..\\Utilities\\Images\\" + fileName);
                FileStream l_fileStream = new FileStream(l_absoluteFilePath, FileMode.Open, FileAccess.Read);
                BinaryReader l_binaryReader = new BinaryReader(l_fileStream, System.Text.Encoding.UTF8);
                byte[] l_imageBytes = l_binaryReader.ReadBytes((int)l_fileStream.Length);
                byte[] l_firstEightBytes = l_imageBytes[0..8];
                string l_mediaFormat = GetImageFormat(l_firstEightBytes);
                string l_data = ";base64" +","+ System.Convert.ToBase64String(l_imageBytes);
                l_fileStream.Close();
                l_binaryReader.Close();
                return "data:image/" + l_mediaFormat + l_data;
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                throw new System.Exception(message: fileNotFoundException.Message + "|" + "get uri failure");
            }
            catch (System.Exception e)
            {
                throw new System.Exception(message: e.Message);
            }
        }

        private static string GetImageFormat(byte[] bytes)
        {
            if(bytes.CompareByteArray(JPG_SIGNATURE, 3))
            {
                return ImageFormat.jpg.ToString();
            }else if(bytes.CompareByteArray(PNG_SIGNATURE, 8))
            {
                return ImageFormat.png.ToString();
            }
            throw new System.Exception("No signature determinated");
        }

        private static bool CompareByteArray(this byte[] fbs, byte[] sbs, int range=0){
            int l_fl = fbs.Length;
            int l_sl = sbs.Length;
            int l_lim = l_fl < l_sl ? l_fl : l_sl;
            if(range > l_lim) return false;
            for(int i=0;i<range; i++)
            {
                if (fbs[i] != sbs[i]) return false;
            }
            return true;
        }
    }
}
