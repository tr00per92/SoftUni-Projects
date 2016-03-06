namespace Scripts
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public class WelcomeScreen : MonoBehaviour
    {
        public GameObject startGameButton;

        private void Start()
        {
            startGameButton.GetComponent<TweenAlpha>().Toggle();
        }

        public void StartGame()
        {
            Application.LoadLevel("MainWorld");
        }
    }
}
