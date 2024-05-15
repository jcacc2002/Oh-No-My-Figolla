using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class responsible for starting the game.
/// </summary>
public class StartGame : MonoBehaviour
{
    /// <summary>
    /// Called when the object is clicked.
    /// </summary>
    private void OnMouseUpAsButton()
    {
        LoadGameScene("Oven");
    }

    /// <summary>
    /// Loads the specified game scene.
    /// </summary>
    /// <param name="sceneName">Name of the scene to load.</param>
    private void LoadGameScene(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("Scene name is null or empty!");
            return;
        }

        try
        {
            SceneManager.LoadScene(sceneName);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Failed to load scene {sceneName}: {ex.Message}");
        }
    }
}