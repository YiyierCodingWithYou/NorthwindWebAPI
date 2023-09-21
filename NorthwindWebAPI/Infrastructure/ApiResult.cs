namespace NorthwindWebAPI.Infrastructure
{
	public class ApiResult
	{
		public bool IsSuccess { get; private set; }
		public bool IsFail => !IsSuccess;
		public string Message { get; private set; }

		public static ApiResult Success(string successMessage) => new ApiResult { IsSuccess = true, Message = successMessage };
		public static ApiResult Fail(string errorMessage) => new ApiResult { IsSuccess = false, Message = errorMessage };
	}
}
