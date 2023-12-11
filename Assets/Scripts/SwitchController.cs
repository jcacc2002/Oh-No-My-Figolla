﻿using UnityEngine;
using UnityEngine.UI;


namespace Figolla
{
    public class SwitchController : BaseController
    {
        [SerializeField] private SpriteRenderer light;
        [SerializeField] private Color on;
        [SerializeField] private Color off;
        private bool toggle = false;
        public override void Click(Vector2 position)
        {
            toggle = !toggle;
            Debug.Log(toggle);

            if (toggle)
            {
                light.color = on;
            }
            else
            {
                light.color = off;
            }
        }


        void OnButtonClick()
        {
            Vector2 clickPosition = Input.mousePosition;
            Click(clickPosition);
        }
    }
}