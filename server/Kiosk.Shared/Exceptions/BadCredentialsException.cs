namespace Kiosk.Shared.Exceptions
{
    public class BadCredentialsException: Exception
    {
        public BadCredentialsException(): base("Bad credentials") { }
    }
}
