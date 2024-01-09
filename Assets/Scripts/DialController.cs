using System;
using UnityEngine;
using UnityEngine.UI;
using Figolla;

public class DialController : BaseController
{
    public Transform dialTransform;
    public float rotationSpeed = 45f;
    
    public TextController textController;
    
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
        rotationCount++;
        UpdateTextController();
    }
    
    private void UpdateTextController()
    {
        if (textController != null)
        {
            textController.UpdateDialValue(rotationCount, isClockwise);
        }
    }
    
    public void ResetRotations()
    {
        rotationCount = 0;
    }

    private void RotateDial(float angle)
    {
        dialTransform.Rotate(Vector3.forward * angle);
    }
}
