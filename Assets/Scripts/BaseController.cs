using System;
using Figolla;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    public abstract void Click(Vector2 position);

    public TextController GameManager { get; private set; }

    protected virtual void Awake()
    {
        GameManager = FindObjectOfType<TextController>();
    }
}