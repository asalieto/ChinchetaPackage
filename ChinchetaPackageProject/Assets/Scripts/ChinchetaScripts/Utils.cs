using UnityEngine;

namespace ChinchetaGames
{
    public static class Utils
    {
        public static void OnWebsiteClick()
        {
            Application.OpenURL(k_websiteUrl);
        }

        public static void RateThisApp()
        {
            Application.OpenURL("http://play.google.com/store/apps/details?id=" + Application.identifier);
        }

        public static void OpenFunkyChicken()
        {
            Application.OpenURL("http://play.google.com/store/apps/details?id=com.ChinchetaGames.FunkyChicken");
        }

        public static void OpenChinchetaGames()
        {
            Application.OpenURL("https://play.google.com/store/apps/developer?id=Chincheta+Games");
        }

        private const string k_websiteUrl = "www.albertosalieto.es";
    }
}