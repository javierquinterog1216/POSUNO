using System;
using System.Collections.Generic;
using System.Text;
using Windows.Storage;

namespace POSUNO.Helpers
{
    public class Settings
    {
        private static readonly ApplicationDataContainer _localSetting = ApplicationData.Current.LocalSettings;

        public static string GetApiUrl()
        {
            return (string)_localSetting.Values["ApiUrl"];
        }

    }
}
