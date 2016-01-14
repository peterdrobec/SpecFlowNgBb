using System.Configuration;
using System;

namespace SpecFlowNg.Helpers
{
    public class EnvironmentSettings
    {
        public string BaseUrl => GetEnvSetting("baseUrl");
        
        public string ValidUserName => GetEnvSetting("validUserName");

        public string ValidPassword => GetEnvSetting("validPassword");
 
        //private string GetDecryptedSetting(string key)
        //{
        //    return GetAppSetting(key);
        //}

        private string GetEnvSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
