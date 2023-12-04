using System;
using UnityEngine;
using UnityEngine.UI;

public class DialController : BaseController
{
    public Transform dialTransform;
    public float rotationSpeed = 45f;

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
        }

        else
        {
            RotateDial(rotationSpeed);
        }
    }

    private void RotateDial(float angle)
    {
        dialTransform.Rotate(Vector3.forward * angle);
    }
}
