using System;
using Figolla;
using UnityEngine;

/// <summary>
/// Abstract base class for controllers.
/// Provides basic functionality and structure for derived controllers.
/// </summary>
public abstract class BaseController : MonoBehaviour
{
    /// <summary>
    /// Abstract method to handle click events.
    /// </summary>
    /// <param name="position">Position where the click occurred.</param>
    public abstract void Click(Vector2 position);

    /// <summary>
    /// Reference to the GameManager (TextController).
    /// </summary>
    public TextController GameManager { get; private set; }

    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    protected virtual void Awake()
    {
        GameManager = FindObjectOfType<TextController>();
    }
}