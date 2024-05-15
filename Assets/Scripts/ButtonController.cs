using UnityEngine;
using UnityEngine.UI;

namespace Figolla
{
    /// <summary>
    /// Controller for handling button click events.
    /// </summary>
    public class ButtonController : BaseController
    {
        /// <summary>
        /// Audio source to play when the button is clicked.
        /// </summary>
        [SerializeField]
        private AudioSource buttonSound;

        protected override void Awake()
        {
            base.Awake();
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
            Debug.Log("Button Clicked");
            UpdatePlayerIntValue();
            if (buttonSound != null)
            {
                buttonSound.Play();
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
        /// Updates the player's integer value in the game manager.
        /// </summary>
        private void UpdatePlayerIntValue()
        {
            GameManager.AddValue(1);
        }
    }
}