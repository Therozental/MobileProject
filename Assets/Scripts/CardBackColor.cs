using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class CardBackColor : MonoBehaviour
{
    [SerializeField] private GameObject cardBack;
    [SerializeField] private Image cardBackImage; // Reference to the card's back UI Image
   // [SerializeField] private Sprite[] backImages; // Array of images for the card back
    public List<Sprite> cardBackImages = new List<Sprite>();
    [SerializeField] private int imageNumber = 0; // Default back image
    public int currentBackIndex = 0;

    private void Start()
    {
        // Set the default card back appearance at the start
        //SetCardBack();
        cardBackImage.sprite = cardBackImages[imageNumber]; // Change the image
        currentBackIndex = imageNumber;
    }
    
    public void SetCardBack(int index)
    {
        // Sets the card back to a specific color and image.
        if (index >= 0 && index < cardBackImages.Count)
        {
            cardBackImage.sprite = cardBackImages[index]; // Change the image
            currentBackIndex = index;
        }
        else
        {
            Debug.LogWarning("Invalid card back index: " + index);
        }
    }
   
    public void ChangeBackImage()
    {
        // Cycles to the next card back in the list.
        int nextIndex = (currentBackIndex + 1) % Mathf.Min(cardBackImages.Count);
        SetCardBack(nextIndex);
    }
}
