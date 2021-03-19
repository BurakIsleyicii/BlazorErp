using BlazorErp.Client.Infrastructure.Settings;
using MudBlazor;
using System.Threading.Tasks;

namespace BlazorErp.Client.Infrastructure.Managers.Preferences
{
    public interface IPreferenceManager
    {
        Task SetPreference(Preference preference);

        Task<Preference> GetPreference();

        Task<MudTheme> GetCurrentThemeAsync();

        Task<bool> ToggleDarkModeAsync();

        Task ChangeLanguageAsync(string languageCode);
    }
}