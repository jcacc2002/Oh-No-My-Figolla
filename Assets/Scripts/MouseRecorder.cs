using UnityEngine;

namespace Figolla
{
    /// <summary>
    /// Records mouse clicks and notifies the relevant controller.
    /// </summary>
    public class MouseRecorder : MonoBehaviour
    {
        private void Update()
        {
            // Check for mouse click
            if (Input.GetMouseButtonDown(0)) 
            {
                // Get the mouse click position in screen coordinates
                Vector3 mouseClickPosition = Input.mousePosition;

                // Convert the screen coordinates to world coordinates
                Vector3 worldClickPosition = Camera.main.ScreenToWorldPoint(mouseClickPosition);
                
                // Debug.Log("Mouse Click Position (Screen): " + mouseClickPosition);
                // Debug.Log("Mouse Click Position (World): " + worldClickPosition);

                // Check for a collider at the click position
                Collider2D col = Physics2D.OverlapPoint(worldClickPosition);

                if (col != null)
                {
                    BaseController controller = col.GetComponent<BaseController>();
                    if (controller != null)
                    {
                        controller.Click(worldClickPosition);
                    }
                    else
                    {
                        Debug.LogWarning("No BaseController component found on the clicked object.");
                    }
                }
            }
        }
    }
}




