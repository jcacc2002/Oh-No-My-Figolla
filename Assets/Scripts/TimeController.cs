using System.Collections;
using UnityEngine;
using TMPro;

namespace Figolla
{
    /// <summary>
    /// Controls the countdown timer displayed on the screen.
    /// </summary>
    public class TimeController : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI timerText;  // Assign this in the Unity Editor

        private readonly float initialWaitTime = 4.0f;
        private readonly float[] countdownTimes = { 4.0f, 3.0f, 2.0f, 1.5f };
        private readonly int[] countdownRepeats = { 10, 10, 20, int.MaxValue }; // int.MaxValue for indefinite

        private void Start()
        {
            StartCoroutine(TimerRoutine());
        }

        /// <summary>
        /// Manages the countdown timer routine.
        /// </summary>
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
                    yield return StartCoroutine(CountdownRoutine(countdownTime));
                }
            }
        }

        /// <summary>
        /// Handles the countdown for a specific duration.
        /// </summary>
        /// <param name="countdownTime">The duration for the countdown.</param>
        private IEnumerator CountdownRoutine(float countdownTime)
        {
            float timeLeft = countdownTime;
            while (timeLeft > 0)
            {
                UpdateTimerText(timeLeft);
                timeLeft -= Time.deltaTime;
                yield return null;
            }

            // Update for end of countdown
            UpdateTimerText(0);

            // Wait for 3 seconds between countdowns
            yield return new WaitForSeconds(3.0f);
        }

        /// <summary>
        /// Updates the timer text on the screen.
        /// </summary>
        /// <param name="time">The time to display.</param>
        private void UpdateTimerText(float time)
        {
            if (timerText != null)
            {
                timerText.text = $"{time:F1}";
            }
            else
            {
                Debug.LogWarning("TimerText is not assigned!");
            }
        }
    }
}