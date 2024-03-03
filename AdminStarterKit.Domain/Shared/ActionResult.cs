using System.Globalization;

namespace AdminStarterKit.Domain.Shared
{
    public class ActionResult
    {
        public bool Succeeded { get; protected set; }
        public List<string> Errors { get; set; } = [];

        public static ActionResult Success => new() { Succeeded = true };

        public static ActionResult Failed(List<string> errors)
        {
            var result = new ActionResult { Succeeded = false };
            if (errors!=null)
            {
                result.Errors.AddRange(errors);
            }
            return result;
        }

        public override string ToString()
        {
            return Succeeded ?
                   "Succeeded" :
                   string.Format(CultureInfo.InvariantCulture, "{0} : {1}", "Failed", string.Join(",", Errors.Select(x => x).ToList()));
        }
    }
}
