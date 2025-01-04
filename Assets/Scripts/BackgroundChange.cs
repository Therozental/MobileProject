using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundChange : MonoBehaviour
{
    
    [SerializeField] private Image backgroundImage; // Reference to the UI Image component
    [SerializeField] private Sprite[] backgroundSprites; // Array of 5 background sprites
    [SerializeField] private int defaultBackgroundIndex = 0; // Default background index (0-based)
    private int currentBackgroundIndex; // Tracks the current background

    public void Start()
    {
        // Set the default background at the start of the game
        SetBackground(defaultBackgroundIndex);
    }
    
    public void SetBackground(int index)
    {
        // Changes the background to the specified index.
        if (index >= 0 && index < backgroundSprites.Length)
        {
            backgroundImage.sprite = backgroundSprites[index];
            currentBackgroundIndex = index;
        }
        else
        {
            Debug.LogWarning("Invalid background index: " + index);
        }
    }

    public void ChangeBackground()
    {
        // Cycles to the next background in the list.
        int nextIndex = (currentBackgroundIndex + 1) % backgroundSprites.Length;
        SetBackground(nextIndex);
    }

    /// <summary>
    /// Cycles to the previous background in the list.
    /// </summary>
    public void PreviousBackground()
    {
        int previousIndex = (currentBackgroundIndex - 1 + backgroundSprites.Length) % backgroundSprites.Length;
        SetBackground(previousIndex);
    }
}