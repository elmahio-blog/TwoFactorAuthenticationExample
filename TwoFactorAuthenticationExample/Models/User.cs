namespace TwoFactorAuthenticationExample.Models
{
    public class CurrentUser
    {
        public static CurrentUser PreviousUser { get; set; }

        public static CurrentUser SignedInUser { get; set; }

        public string Email { get; set; }

        public bool TwoFactorEnabled { get; set; }
    }
}
