using UnityEngine;

namespace ChinchetaGames
{
    public class UserState
    {
        public void LoadUserConfig()
        {
            // string stringId = PlayerPrefs.GetString("stringId");
            // 
            // if (!string.IsNullOrEmpty(stringId))
            // {
            // }
        }

        public void SetUserConfig(string stringId, string value)
        {
            PlayerPrefs.SetString("stringId", value);
        }
    }
}