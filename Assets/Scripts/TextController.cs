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

        private List<string> sentences = new List<string>()
        {
            "Dial clockwise, 4.",
            "Switch on.",
            "Button press 6 times."
        };

        private string lastInstruction = string.Empty;

            void Start()
        {
            screenText = GetComponent<TextMeshProUGUI>();
            screenText.text = "FEED ME!";
            
            StartCoroutine(ChangeTextRoutine());
            
        }
            
            private IEnumerator ChangeTextRoutine()
            {
                while (true)
                {
                    yield return new WaitForSeconds(timer);
                    int rnd = Random.Range(0, sentences.Count);
                    string randomSentence = sentences[rnd];
                    sentences.RemoveAt(rnd);
                    screenText.text = randomSentence;
                    
                    if (lastInstruction != string.Empty)
                    {
                        sentences.Add(lastInstruction);
                    }

                    lastInstruction = randomSentence;
                }
            }
        
    }
}