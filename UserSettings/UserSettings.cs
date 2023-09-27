using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGPS_Help_Desk.UserSettings
{
    internal class UserSettings : ApplicationSettingsBase
    {
        [UserScopedSetting()]
        public string SiteId { get; set; }
    }
}
