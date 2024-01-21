using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

namespace Figolla
{
    public class TextController : MonoBehaviour
    {
        
        private int score = 0; 
        private static string highScoreFilePath;
        
        
        private void Awake()
        {
            highScoreFilePath = Path.Combine(Application.persistentDataPath, "highscore.txt");
        }
        
        private void IncreaseScore()
        {
            score++;
            
        }
        
        private TextMeshProUGUI screenText;
        private int timer = 4;
        private int timer3 = 3;
        public AudioSource successSound;
        public AudioSource patheticSound;



        private List<string> sentences = new List<string>();
        
        public Dictionary<string, DataType> instructions = new Dictionary<string, DataType>()
        {
            { "Clockwise {n}", DataType.Integer },
            { "Anti-clockwise {n}", DataType.Integer },
            { "Switch {n}", DataType.Boolean },
            { "Button {n} times", DataType.Integer }
        };

        private string lastInstruction = string.Empty;
        

        void Start()
        {
            screenText = GetComponent<TextMeshProUGUI>();
            sentences.AddRange(instructions.Keys);
            StartCoroutine(ChangeTextRoutine());
        }
            
        private int targetIntValue;
        private int playerIntValue;
        private bool targetBoolValue;
        private bool playerBoolValue;

        
        private IEnumerator ChangeTextRoutine()
        {
            screenText.text = "FEED ME!";
            yield return new WaitForSeconds(timer);
            

            while (true)
            {
                int rnd = Random.Range(0, sentences.Count);
                string randomSentence = sentences[rnd];
                sentences.RemoveAt(rnd);
                
                // check what data type needs to be used.
                DataType type = instructions[randomSentence];

                switch (type)
                {
                    case DataType.Integer:
                        targetIntValue = Random.Range(1, 11);
                        playerIntValue = 0;
                        screenText.text = randomSentence.Replace("{n}", targetIntValue.ToString());;
                        break;
                    case DataType.Boolean:
                        targetBoolValue = Random.Range(0, 2) == 1;
                        playerIntValue = 0;
                        screenText.text = randomSentence.Replace("{n}", targetBoolValue ? "on" : "off");;
                        break;
                }
                
                // reset the player's current value
                
                if (lastInstruction != string.Empty)
                {
                    sentences.Add(lastInstruction);
                }

                lastInstruction = randomSentence;
                //Debug.Log(instructions[lastInstruction]);
                yield return new WaitForSeconds(timer);
                bool isCorrect = false; // Variable to check if the player's answer is correct

                switch (type)
                {
                    case DataType.Integer:
                        isCorrect = playerIntValue == targetIntValue;
                        screenText.text = isCorrect ? "Success" : "Pathetic";
                        break;
                    case DataType.Boolean:
                        isCorrect = playerBoolValue == targetBoolValue;
                        screenText.text = isCorrect ? "Success" : "Pathetic";
                        break;

                }
                
                if (isCorrect)
                {
                    IncreaseScore(); // Increase score only if the answer is correct
                    if (successSound != null)
                    {
                        successSound.Play();
                    }
                }
                else
                {
                    if (patheticSound != null)
                    {
                        patheticSound.Play();
                    }
                    SaveScoreAndCompare();
                }
                yield return new WaitForSeconds(timer3);



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
                
                //Debug.Log(score);
                
                DialReset();
            }
        }

        public void AddValue(int value)
        {
            playerIntValue += value;
          //  Debug.Log(playerIntValue);
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
            return 0; // Default to 0 if no high score is found or if there's an issue reading the file
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