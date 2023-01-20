using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client
{
    public class UICanvas : MonoBehaviour
    {
        public UIHudPanel hud;
        public UIDeathScreen deathScreen;

        void Awake()
        {
            hud.SetScores(0);
            hud.SetHealth(100);
            ShowHud();
        }

        public void ShowHud()
        {
            hud.gameObject.SetActive(true);
            deathScreen.gameObject.SetActive(false);
        }
        
        public void ShowDeathScreen()
        {
            hud.gameObject.SetActive(false);
            deathScreen.gameObject.SetActive(true);
        }

        public void RestartScene()
        {
            SceneManager.LoadScene(gameObject.scene.name);
        }
    };
}