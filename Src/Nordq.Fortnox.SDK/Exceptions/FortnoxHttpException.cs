using System;
using System.Net.Http;

namespace Nordq.Fortnox.SDK.Exceptions
{
    public class FortnoxHttpException : HttpRequestException
    {
        public override string Message { get; }
        public Type Type { get; }

        public FortnoxHttpException(string message, Type t)
        {
            Message = message;
            Type = t;
        }
    }
}
