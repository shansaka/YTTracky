namespace YTTracky.Api.Common
{
    public class BaseResponse<T>
    {
        public BaseResponse(bool isSuccess = true,string ? error = null)
        {
            this.Error = error;
            this.IsSuccess = IsSuccess;
        }

        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }
    }
}
