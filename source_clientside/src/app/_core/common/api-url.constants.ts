export class ApiUrlConstants{
    public static API_URL = "https://localhost:44350";
    //user API
    //public static API_ATHENTICATE_URL= '/user/authenticate'
    public static API_REFRESHTOKEN_URL= '/user/refresh-token/'
    //public static API_REGISTER_URL= '/user/register'
    public static API_UPDATE_PROFILE_URL = '/user/profile/'
    public static API_UPDATE_INTEREST_URL = '/user/interest/'
    public static API_UPDATE_PASSWORD_URL = '/user/password/'
    public static API_UPDATE_ACADEMIC_URL = '/user/academic/'
    public static API_UPDATE_AVATAR_URL = '/user/avatar/'
    public static API_UPDATE_BACKGROUND_URL ='/user/background/'
    public static API_LOAD_LISTFRIENDS_URL = '/user/search?name='
    public static API_LOAD_USERBYID_URL = '/user/timeline-user/'
    public static API_LOAD_MAINUSER_URL = '/user/load'
    public static API_SEND_OTP_URL = '/otp/send-email-otp'
    public static API_REGISTER_URL = '/identity/register'
    public static API_LOGIN_URL = '/identity/authenticate'
    //admin API
    public static API_ADMIN_URL = '/admin/'
    //trip API
    public static API_TRIP_URL = '/trip/'
    public static API_TRIPLOAD_URL = '/trip/load/'
    public static API_FRIENDSINTRIP_URL = '/invitefriend/'
    public static API_FRIENDSINTRIPLOAD_URL = '/invitefriend/load?tripid='
    public static API_PAYMENTHISTORY_URL = '/invitefriend/history?userId='
    //media API
    public static API_MEDIA_URL = '/media'

    //pages API
    public static API_PAGE_URL = '/page/load'
    public static API_PAGEID_URL = '/page/'
    public static API_UPDATE_PAGEAVATAR_URL = '/page/avatar'
    public static API_UPDATE_PAGEBACKGROUND_URL ='/page/background'
}