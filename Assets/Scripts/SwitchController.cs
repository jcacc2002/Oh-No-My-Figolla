using UnityEngine;
using UnityEngine.UI;

namespace Figolla
{
    /// <summary>
    /// Controller for handling switch click events.
    /// </summary>
    public class SwitchController : BaseController
    {
        [SerializeField]
        private SpriteRenderer light;

        [SerializeField]
        private Color on;

        [SerializeField]
        private Color off;

        private bool toggle = false;

        [SerializeField]
        private TextController textController;

        [SerializeField]
        private AudioSource onSound;

        [SerializeField]
        private AudioSource offSound;

        protected override void Awake()
        {
            base.Awake();
            // Ensure button click event is bound
            Button button = GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(OnButtonClick);
            }
        }

        /// <summary>
        /// Handles click events at the specified position.
        /// </summary>
        /// <param name="position">The position where the click occurred.</param>
        public override void Click(Vector2 position)
        {
            toggle = !toggle;
            Debug.Log(toggle);

            UpdateLightColor();
            PlaySound();

            if (textController != null)
            {
                textController.UpdateSwitchStateText(toggle);
            }
            else
            {
                Debug.LogWarning("TextController not assigned!");
            }
        }

        /// <summary>
        /// Invoked when the button is clicked.
        /// </summary>
        private void OnButtonClick()
        {
            Vector2 clickPosition = Input.mousePosition;
            Click(clickPosition);
        }

        /// <summary>
        /// Updates the light color based on the toggle state.
        /// </summary>
        private void UpdateLightColor()
        {
            light.color = toggle ? on : off;
        }

        /// <summary>
        /// Plays the appropriate sound based on the toggle state.
        /// </summary>
        private void PlaySound()
        {
            if (toggle && onSound != null)
            {
                onSound.Play();
            }
            else if (!toggle && offSound != null)
            {
                offSound.Play();
            }
            else
            {
                Debug.LogWarning("Sound not assigned!");
            }
        }
    }
}