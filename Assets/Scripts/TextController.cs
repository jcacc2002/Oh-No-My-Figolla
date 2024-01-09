using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Figolla
{
    public class TextController : MonoBehaviour
    {
        public TextMeshProUGUI screenText;
        public int timer;
        public int timer3;



        private List<string> sentences = new List<string>();
        
        public Dictionary<string, DataType> instructions = new Dictionary<string, DataType>()
        {
            { "Clockwise {n}", DataType.Integer },
            { "Anti-clockwise {n}", DataType.Integer },
            { "Switch {n}", DataType.Boolean },
            { "Button {n} times", DataType.Integer }
        };

        public string lastInstruction = string.Empty;
        

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
                Debug.Log(instructions[lastInstruction]);
                yield return new WaitForSeconds(timer);

                switch (type)
                {
                    case DataType.Integer:
                        screenText.text = playerIntValue == targetIntValue ? "Success" : "Pathetic";
                        break;
                    case DataType.Boolean:
                        screenText.text = playerBoolValue == targetBoolValue ? "Success" : "Pathetic";
                        break;

                }
                yield return new WaitForSeconds(timer3);
                
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
        
        
    }

    public enum DataType
    {
        Integer,
        Boolean
    }
}