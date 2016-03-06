namespace Scripts
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public class GameOver : MonoBehaviour
    {
        public GameObject headerLabel;
        public GameObject footerLabel;
        public GameObject exitButton;

        private void Start()
        {
            this.headerLabel.GetComponent<TweenPosition>().PlayForward();
        }

        private void Update()
        {
            if (this.headerLabel.GetComponent<TweenPosition>().tweenFactor == 1f)
            {
                if (this.footerLabel.GetComponent<TweenPosition>().tweenFactor == 0f)
                {
                    this.footerLabel.GetComponent<TweenPosition>().PlayForward();
                }
                else if (this.footerLabel.GetComponent<TweenPosition>().tweenFactor == 1f)
                {
                    if (this.exitButton.GetComponent<TweenAlpha>().tweenFactor == 0f)
                    {
                        this.exitButton.GetComponent<TweenAlpha>().PlayForward();
                    }
                }
            }
        }

        public void Click()
        {
            Application.Quit();
        }
    }
}
