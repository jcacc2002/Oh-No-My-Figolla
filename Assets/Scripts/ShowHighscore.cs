using UnityEngine;
using TMPro; // Make sure to include this if you're using TextMeshPro for your UI text elements
using System.IO;

public class ShowHighscore : MonoBehaviour
{
    public TextMeshProUGUI highScoreText; // Assign this in the inspector

    private static string GetHighScoreFilePath()
    {
        return Path.Combine(Application.persistentDataPath, "highscore.txt");
    }

    private void Start()
    {
        DisplayHighScore();
    }

    private void DisplayHighScore()
    {
        string filePath = GetHighScoreFilePath();
        if (File.Exists(filePath))
        {
            string highScoreStr = File.ReadAllText(filePath);
            highScoreText.text = $"Congratulations! High Score: {highScoreStr}";
        }
        else
        {
            highScoreText.text = "High Score: 0";
        }
    }
}