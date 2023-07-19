namespace LibraryMgmt.WebApp.MVC.DTOs
{
    public class UserAuthTokenDTO_client
    {

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string AccessToken { get; set; }
    }
}
