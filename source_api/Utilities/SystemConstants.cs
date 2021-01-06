namespace Utilities
{
    public static class SystemConstants
    {
        public static char DIRECTORY_SEPARATOR_CHAR = System.IO.Path.DirectorySeparatorChar;
        public static string WWWROOT_DIRECTORY = System.IO.Directory.GetCurrentDirectory() + DIRECTORY_SEPARATOR_CHAR + "wwwroot";
        public static string MEDIA_DIRECTORY = "media-file";
        public static string FAKE_POST_MEDIA_DIRECTORY = MEDIA_DIRECTORY + DIRECTORY_SEPARATOR_CHAR + "fake_post_media";
    }
}
