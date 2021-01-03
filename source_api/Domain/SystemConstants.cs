namespace Domain.Services
{
    public static class SystemConstants
    {
        public static string WWWROOT_DIRECTORY = System.IO.Directory.GetCurrentDirectory() + "\\wwwroot";
        public static string MEDIA_DIRECTORY = "media-file";
        public static string FAKE_POST_MEDIA_DIRECTORY = MEDIA_DIRECTORY + "\\" + "fake_post_media";
    }
}
