using UnityEngine;

namespace ChinchetaGames
{
    public class Loader : MonoBehaviour
    {
        void Start()
        {
            DontDestroyOnLoad(this);

            GameManager.Instance.InitVars();
            UIManager.Instance.Init();
        }
    }
}