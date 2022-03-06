using System;
using System.Collections;
using System.Collections.Generic;

namespace WebApi.WebApi.Toolkit
{
    public class ResultContent<T> : IEnumerable<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Content { get; set; }
        public Exception Exception { get; set; }
        private IEnumerable<T> ContentCollection { get; set; }

        public ResultContent<T> Ok(T content, string message = "")
        {
            return new()
            {
                IsSuccess = true,
                Message = message,
                Content = content
            };
        }

        public ResultContent<T> Ok(string message = "")
        {
            return new()
            {
                IsSuccess = true,
                Message = message,
            };
        }

        public ResultContent<T> Error(string message = "")
        {
            return new()
            {
                IsSuccess = false,
                Message = message
            };
        }

        public ResultContent<T> Error(Exception exception, string message = "")
        {
            return new()
            {
                IsSuccess = false,
                Message = string.IsNullOrWhiteSpace(message) is false ? message : exception.Message,
                Exception = exception
            };
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ContentCollection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)ContentCollection).GetEnumerator();
        }
    }
}
