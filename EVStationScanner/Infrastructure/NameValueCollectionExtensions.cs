using System;
using System.Collections.Specialized;
using System.Configuration;

namespace EVStationScanner.Infrastructure
{
    public static class NameValueCollectionExtensions
    {
        public static string GetString(this NameValueCollection collection, string key, bool isRequired = false)
        {
            var value = collection.Get(key);

            if (isRequired && string.IsNullOrWhiteSpace(value))
                throw new ConfigurationErrorsException($"Configuration setting for key '{key}' is missing.");

            return value;
        }

        public static int? GetInt(this NameValueCollection collection, string key, bool isRequired = false)
        {
            var value = GetString(collection, key, isRequired);

            if (string.IsNullOrWhiteSpace(value))
                return null;

            if (!int.TryParse(value, out var result)) 
                throw new ConfigurationErrorsException($"Configuration setting for key '{key}' is not a valid integer.");

            return result;
        }

        public static Uri GetUri(this NameValueCollection collection, string key, UriKind uriKind, bool isRequired = false)
        {
            var value = GetString(collection, key, isRequired);

            if (string.IsNullOrWhiteSpace(value))
                return null;

            if (!Uri.TryCreate(value, uriKind, out var result))
                throw new ConfigurationErrorsException($"Configuration setting for key '{key}' is not a valid uri.");

            return result;
        }
    }
}