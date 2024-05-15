using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Figolla
{
    /// <summary>
    /// Manages the text instructions and player interactions.
    /// </summary>
    public class TextController : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI screenText;

        [SerializeField]
        private AudioSource successSound;

        [SerializeField]
        private AudioSource patheticSound;

        private int score = 0; 
        private static string highScoreFilePath;
        private int timer = 4;
        private int timer3 = 3;

        private int targetIntValue;
        private int playerIntValue;
        private bool targetBoolValue;
        private bool playerBoolValue;

        private List<string> sentences = new List<string>();
        private string lastInstruction = string.Empty;

        public Dictionary<string, DataType> instructions = new Dictionary<string, DataType>()
        {
            { "Clockwise {n}", DataType.Integer },
            { "Anti-clockwise {n}", DataType.Integer },
            { "Switch {n}", DataType.Boolean },
            { "Button {n} times", DataType.Integer }
        };

        private void Awake()
        {
            highScoreFilePath = Path.Combine(Application.persistentDataPath, "highscore.txt");
        }

        private void Start()
        {
            screenText = GetComponent<TextMeshProUGUI>();
            sentences.AddRange(instructions.Keys);
            StartCoroutine(ChangeTextRoutine());
        }

        private IEnumerator ChangeTextRoutine()
        {
            screenText.text = "FEED ME!";
            yield return new WaitForSeconds(timer);

            while (true)
            {
                int rnd = Random.Range(0, sentences.Count);
                string randomSentence = sentences[rnd];
                sentences.RemoveAt(rnd);
                
                // Check what data type needs to be used.
                DataType type = instructions[randomSentence];

                switch (type)
                {
                    case DataType.Integer:
                        targetIntValue = Random.Range(1, 11);
                        playerIntValue = 0;
                        screenText.text = randomSentence.Replace("{n}", targetIntValue.ToString());
                        break;
                    case DataType.Boolean:
                        targetBoolValue = Random.Range(0, 2) == 1;
                        playerIntValue = 0;
                        screenText.text = randomSentence.Replace("{n}", targetBoolValue ? "on" : "off");
                        break;
                }

                if (lastInstruction != string.Empty)
                {
                    sentences.Add(lastInstruction);
                }

                lastInstruction = randomSentence;
                yield return new WaitForSeconds(timer);

                bool isCorrect = CheckPlayerInput(type);

                screenText.text = isCorrect ? "Success" : "Pathetic";

                if (isCorrect)
                {
                    IncreaseScore();
                    PlaySound(successSound);
                }
                else
                {
                    PlaySound(patheticSound);
                    SaveScoreAndCompare();
                }

                yield return new WaitForSeconds(timer3);
                AdjustTimerBasedOnScore();
                DialReset();
            }
        }

        private bool CheckPlayerInput(DataType type)
        {
            switch (type)
            {
                case DataType.Integer:
                    return playerIntValue == targetIntValue;
                case DataType.Boolean:
                    return playerBoolValue == targetBoolValue;
                default:
                    return false;
            }
        }

        private void AdjustTimerBasedOnScore()
        {
            if (score == 10)
            {
                timer = 3;
            }
            else if (score == 20)
            {
                timer = 2;
            }
            else if (score == 40)
            {
                timer = (int)1.5;
            }
        }

        private void IncreaseScore()
        {
            score++;
        }

        private void PlaySound(AudioSource sound)
        {
            if (sound != null)
            {
                sound.Play();
            }
        }

        public void AddValue(int value)
        {
            playerIntValue += value;
        }

        public bool UpdateSwitchStateText(bool isOn)
        {
            playerBoolValue = isOn;
            return isOn;
        }

        public void UpdateDialValue(int rotationCount, bool isClockwise)
        {
            if (lastInstruction.Contains("Clockwise") && isClockwise)
            {
                playerIntValue = rotationCount;
            }
            else if (lastInstruction.Contains("Anti-clockwise") && !isClockwise)
            {
                playerIntValue = rotationCount;
            }
        }

        private void DialReset()
        {
            DialController dialController = FindObjectOfType<DialController>();
            if (dialController != null)
            {
                dialController.ResetRotations();
            }
        }

        private int LoadHighScore()
        {
            if (File.Exists(highScoreFilePath))
            {
                string content = File.ReadAllText(highScoreFilePath);
                if (int.TryParse(content, out int highScore))
                {
                    return highScore;
                }
            }
            return 0;
        }

        public void SaveScoreAndCompare()
        {
            int highScore = LoadHighScore();
            Debug.Log($"Current Score: {score}, High Score: {highScore}");
            if (score > highScore)
            {
                File.WriteAllText(highScoreFilePath, score.ToString());
                Debug.Log($"New high score saved: {score}");
                SceneManager.LoadScene("HighScore");
            }
            else
            {
                SceneManager.LoadScene("NotHighScore");
            }
        }
    }

    public enum DataType
    {
        Integer,
        Boolean
    }
}