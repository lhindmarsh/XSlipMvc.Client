namespace XSlipMvc.Client.Application.Common
{
    public class ServiceResult
    {
        public bool Success => !Errors.Any();

        public List<string> Errors { get; } = new();

        public static ServiceResult Ok() => new ServiceResult();

        public static ServiceResult Fail(params string[] errors)
        {
            var result = new ServiceResult();

            result.Errors.AddRange(errors);

            return result;
        }

        public void AddError(string error)
        {
            Errors.Add(error);
        }
    }
}