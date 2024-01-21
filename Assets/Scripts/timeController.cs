using System.Collections;
using UnityEngine;
using TMPro;

namespace Figolla
{
    public class timeController : MonoBehaviour
    {
        public TextMeshProUGUI timerText;  // Assign this in the Unity Editor
        private float initialWaitTime = 4.0f;
        private float[] countdownTimes = new float[] { 4.0f, 3.0f, 2.0f, 1.5f };
        private int[] countdownRepeats = new int[] { 10, 10, 20, int.MaxValue }; // int.MaxValue for indefinite

        private void Start()
        {
            StartCoroutine(TimerRoutine());
        }

        private IEnumerator TimerRoutine()
        {
            // Initial wait before starting the timer
            yield return new WaitForSeconds(initialWaitTime);

            // Loop through the different countdown times
            for (int i = 0; i < countdownTimes.Length; i++)
            {
                float countdownTime = countdownTimes[i];
                int repeatCount = countdownRepeats[i];

                for (int j = 0; j < repeatCount; j++)
                {
                    float timeLeft = countdownTime;
                    while (timeLeft > 0)
                    {
                        timerText.text = $"{timeLeft:F1}";
                        timeLeft -= Time.deltaTime;
                        yield return null;
                    }

                    // Update for end of countdown
                    timerText.text = "0";

                    // Wait for 3 seconds between countdowns
                    yield return new WaitForSeconds(3.0f);
                }
            }
        }
        
    }
}
