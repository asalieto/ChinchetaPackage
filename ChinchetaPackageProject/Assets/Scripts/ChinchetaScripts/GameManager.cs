using UnityEngine;

namespace ChinchetaGames
{
    public class GameManager : Singleton<GameManager>
    {
        public UserState UserState => m_userState;

        public void InitVars()
        {
            m_userState = new UserState();
            m_userState.LoadUserConfig();
        }

        private UserState m_userState = default;

        [SerializeField]
        private UIManager m_uiManager = null;
    }
}