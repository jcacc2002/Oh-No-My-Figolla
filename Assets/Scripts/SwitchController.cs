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
        public TextController textController; 
        
        public AudioSource onSound;
        public AudioSource offSound;
        public override void Click(Vector2 position)
        {
            toggle = !toggle;
            Debug.Log(toggle);

            if (toggle)
            {
                light.color = on;
                if (onSound != null)
                {
                    onSound.Play();
                }
            }
            else
            {
                light.color = off;
                if (offSound != null)
                {
                    offSound.Play();
                }
            }
            
            if(textController != null)
            {
                textController.UpdateSwitchStateText(toggle);
            }
        }


        void OnButtonClick()
        {
            Vector2 clickPosition = Input.mousePosition;
            Click(clickPosition);
        }
    }
}