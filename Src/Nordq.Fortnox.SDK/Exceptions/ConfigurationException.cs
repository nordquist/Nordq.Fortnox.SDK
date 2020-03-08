using System;

namespace Nordq.Fortnox.SDK.Exceptions
{
    public class ConfigurationException : Exception
    {
        public string Key { get; }
        public override string Message { get; }

        public ConfigurationException(string key, string message)
        {
            Message = message;
            Key = key;
        }
    }
}