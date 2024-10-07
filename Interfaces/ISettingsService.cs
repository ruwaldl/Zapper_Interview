namespace Zapper_Interview_Assignment.Interfaces
{
    public interface ISettingsService
    {
        bool CheckUserSettings(string settings, int settingsKey);
        bool SaveSettings(string settingData, int key,string fileName);
        string GetSettings(string fileName);
    }
}
