using System;
namespace Utility
{
	public class Result<T>
	{
		public T Data { get; set; }
		public bool IsSuccess { get; set; }
		public string Message { get; set; }
		public string ValidationMessages { get; set; }
		public Result(T _Data,bool _IsSuccess)
		{
			Data = _Data;
			IsSuccess = _IsSuccess;
		}
        public Result(string _ValidationMessages, bool _IsSuccess)
        {
			ValidationMessages = _ValidationMessages;
            IsSuccess = _IsSuccess;
        }
        public Result(bool _IsSuccess, string _Message)
        {
            Message=_Message;
            IsSuccess = _IsSuccess;
        }
    }
}

