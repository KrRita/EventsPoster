using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsPoster.Service.Settings;

namespace EventsPoster.Service.UnitTests.Helpers
{
    public static class TestSettingsHelper
    {
        public static EventsPosterSettings GetSettings()
        {
            return EventsPosterSettingsReader.Read(ConfigurationHelper.GetConfiguration());
        }
    }
}
