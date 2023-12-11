namespace Figolla
{
    using UnityEngine;
    public class MouseRecorder : MonoBehaviour
    {
        void Update()
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

                Collider2D col = Physics2D.OverlapPoint(worldClickPosition);

                if (col != null)
                {
                    BaseController controller = col.GetComponent<BaseController>();
                    controller.Click(worldClickPosition);
                }
            }
        }
    }
}




