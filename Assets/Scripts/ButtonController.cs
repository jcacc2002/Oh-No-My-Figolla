﻿using UnityEngine;
using UnityEngine.UI;


namespace Figolla
{
    public class ButtonController : BaseController
    {
        public override void Click(Vector2 position)
        {
            Debug.Log("Button Clicked");
            UpdatePlayerIntValue();
        }

        void OnButtonClick()
        {
            Vector2 clickPosition = Input.mousePosition;
            Click(clickPosition);
        }
        
        private void UpdatePlayerIntValue()
        {
            GameManager.AddValue(1);
        }
    }
}