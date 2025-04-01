using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DnfRepeater.Modules
{
    public class UserConfig
    {
        public const int RepeatFrequencyMin = 1;
        public const int RepeatFrequencyMax = 50;
        public const int RepeatFrequencyDefault = 10;
        private const string FileName = "UserConfig.json";

        public string? OnOffHotkey { get; set; }
        public string? RepeatKey { get; set; }
        public string? TriggerKey { get; set; }
        public int RepeatFrequency { get; set; }

        public static UserConfig CreateDefaultConfig()
        {
            return new UserConfig { OnOffHotkey = "Ctrl+`", RepeatKey = "W", TriggerKey = "J", RepeatFrequency = 10 };
        }

        public void UseDefaultValueIfNeed()
        {
            var defaultConfig = CreateDefaultConfig();
            if (string.IsNullOrWhiteSpace(OnOffHotkey))
            {
                OnOffHotkey = defaultConfig.OnOffHotkey;
            }

            if (string.IsNullOrWhiteSpace(RepeatKey))
            {
                RepeatKey = defaultConfig.RepeatKey;
            }

            if (string.IsNullOrWhiteSpace(TriggerKey))
            {
                TriggerKey = defaultConfig.TriggerKey;
            }

            if (RepeatFrequency < RepeatFrequencyMin || RepeatFrequency > RepeatFrequencyMax)
            {
                RepeatFrequency = defaultConfig.RepeatFrequency;
            }
        }

        public static UserConfig Load()
        {
            if (!System.IO.File.Exists(FileName))
            {
                return CreateDefaultConfig();
            }
            var json = System.IO.File.ReadAllText(FileName);
            var userConfig = JsonSerializer.Deserialize<UserConfig>(json) ?? CreateDefaultConfig();
            userConfig.UseDefaultValueIfNeed();

            return userConfig;
        }

        public void Save()
        {
            var json = JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            System.IO.File.WriteAllText(FileName, json);
        }
    }
}
