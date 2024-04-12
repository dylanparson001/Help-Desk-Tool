using System.Configuration;

namespace iGPS_Help_Desk.UserSettings
{
    internal class UserSettings : ApplicationSettingsBase
    {
        [UserScopedSetting()]
        public string SiteId { get; set; }
    }
}
