using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System.Profile;
using Windows.UI.Xaml;

namespace GCores
{
    class DeviceFamilyTrigger : StateTriggerBase
    {
        private string currentDeviceFamily, queriedDeviceFamily;
        public string DeviceFamily
        {
            get
            {
                return queriedDeviceFamily;
            }
            set
            {
                queriedDeviceFamily = value;
                currentDeviceFamily = AnalyticsInfo.VersionInfo.DeviceFamily;
                SetActive(queriedDeviceFamily == currentDeviceFamily);
            }
        }
    }
}
