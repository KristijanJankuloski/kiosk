namespace Kiosk.Shared.Response
{
    public class Response
    {
        public bool IsSuccessful { get; init; }
        public IEnumerable<string> Errors { get; set; } = new List<string>();

        public Response(bool successful)
        {
            IsSuccessful = successful;
        }

        public Response(List<string> errors)
        {
            Errors = errors;
        }

        public Response(params string[] errors)
        {
            Errors = errors;
        }

        public static Response Success => new(true);
    }
}
