using UnityEngine;

namespace ChinchetaGames
{
    public class Menu : MonoBehaviour
    {
        public virtual void Init() { }

        public void Show()
        {
            this.gameObject.SetActive(true);
            OnShow();
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
            OnHide();
        }

        public virtual void OnShow() { }
        public virtual void OnHide() { }
    }
}