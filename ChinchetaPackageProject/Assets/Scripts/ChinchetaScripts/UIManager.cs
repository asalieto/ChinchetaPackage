using UnityEngine;
using System.Collections.Generic;

namespace ChinchetaGames
{
    public class UIManager : Singleton<UIManager>
    {
        public void Init()
        {
            HideAllMenus();

            foreach (Menu menu in m_menuList)
            {
                menu.Init();
            }
        }

        public void HideAllMenus()
        {
            foreach (Menu menu in m_menuList)
            {
                menu.Hide();
            }
        }

        public T GetMenu<T>() where T : Menu
        {
            foreach (Menu menu in m_menuList)
            {
                if (menu is T)
                {
                    return (T)menu;
                }
            }
            return null;
        }

        public void ShowMenu<T>() where T : Menu
        {
            Menu menu = GetMenu<T>();

            if (menu != null)
            {
                menu.Show();
            }
        }

        public void HideMenu<T>() where T : Menu
        {
            Menu menu = GetMenu<T>();

            if (menu != null)
            {
                menu.Hide();
            }
        }

        [SerializeField]
        private List<Menu> m_menuList = null;
    }
}