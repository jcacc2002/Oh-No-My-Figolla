using System;
using UnityEngine;
using UnityEngine.UI;
using Figolla;

public class DialController : BaseController
{
    /// <summary>
    /// Transform of the dial.
    /// </summary>
    [SerializeField]
    private Transform dialTransform;

    /// <summary>
    /// Speed at which the dial rotates.
    /// </summary>
    [SerializeField]
    private float rotationSpeed = 45f;

    /// <summary>
    /// Reference to the TextController.
    /// </summary>
    [SerializeField]
    private TextController textController;

    /// <summary>
    /// Audio source to play when the dial is rotated.
    /// </summary>
    [SerializeField]
    private AudioSource dialSound;

    private int rotationCount = 0;
    private bool isClockwise = true;

    private void Update()
    {
        if (dialTransform == null)
        {
            Debug.LogError("Dial Transform not assigned!");
            return;
        }
    }

    public override void Click(Vector2 position)
    {
        if (position.x > transform.position.x)
        {
            RotateDial(-rotationSpeed);
            isClockwise = true;
        }
        else
        {
            RotateDial(rotationSpeed);
            isClockwise = false;
        }

        if (dialSound != null)
        {
            dialSound.Play();
        }

        rotationCount++;
        UpdateTextController();
    }

    private void UpdateTextController()
    {
        if (textController != null)
        {
            textController.UpdateDialValue(rotationCount, isClockwise);
        }
        else
        {
            Debug.LogWarning("TextController not assigned!");
        }
    }

    public void ResetRotations()
    {
        rotationCount = 0;
    }

    private void RotateDial(float angle)
    {
        if (dialTransform != null)
        {
            dialTransform.Rotate(Vector3.forward * angle);
        }
    }
}