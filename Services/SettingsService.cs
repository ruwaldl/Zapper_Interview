using Zapper_Interview_Assignment.Interfaces;

namespace Zapper_Interview_Assignment.Services
{
    public class SettingsService : ISettingsService
    {
        public bool CheckUserSettings(string settings, int settingsKey)
        {
           var hasAccess = false;
            if (settings[settingsKey - 1] == '1')
            {
                hasAccess = true;
            }
            return hasAccess;
        }

        public string GetSettings(string fileName)
        {
           
            var result = "";
            try
            {
                using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader br = new BinaryReader(file))
                    {
                      
                        while (file.Position < file.Length)
                        {
                            result += br.ReadString() + Environment.NewLine;
                           
                        }
                     
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool SaveSettings(string settingData, int key,string fileName)
        {
            try
            {
                using (FileStream file = new FileStream(fileName, FileMode.Append,FileAccess.Write))
                {
                    using (BinaryWriter bw = new BinaryWriter(file))
                    {
                        var settingsModel = new { Key = key, value = settingData };
                        bw.Write(settingsModel.ToString());
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
