using UnityEngine;
using TMPro; 
using System.IO;

/// <summary>
/// Class responsible for displaying the high score.
/// </summary>
public class ShowHighscore : MonoBehaviour
{
    /// <summary>
    /// TextMeshProUGUI component to display the high score.
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI highScoreText; // Assign this in the inspector

    /// <summary>
    /// Gets the file path for the high score file.
    /// </summary>
    /// <returns>Path to the high score file.</returns>
    private static string GetHighScoreFilePath()
    {
        return Path.Combine(Application.persistentDataPath, "highscore.txt");
    }

    /// <summary>
    /// Unity Start method.
    /// </summary>
    private void Start()
    {
        DisplayHighScore();
    }

    /// <summary>
    /// Reads and displays the high score.
    /// </summary>
    private void DisplayHighScore()
    {
        string filePath = GetHighScoreFilePath();
        if (File.Exists(filePath))
        {
            try
            {
                string highScoreStr = File.ReadAllText(filePath);
                highScoreText.text = $"Congratulations! High Score: {highScoreStr}";
            }
            catch (IOException e)
            {
                Debug.LogError($"Error reading high score file: {e.Message}");
                highScoreText.text = "High Score: Error";
            }
        }
        else
        {
            highScoreText.text = "High Score: 0";
        }
    }
}