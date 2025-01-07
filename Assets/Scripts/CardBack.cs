using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CardBack : MonoBehaviour
{
    [SerializeField] private GameObject cardBackUI; // The UI GameObject
    public Sprite cardSprite; // The current sprite
    public Image cardImage; // The Image component of the card back
    public List<Sprite> backImages = new(); // List of card back sprites

    [SerializeField] private int imageNumber = 0;
/*

    private void Start()
    {
      //  GetComponent(SpriteRenderer).sprite = spriteImage;
        cardImage = cardBackUI.GetComponent<Image>();
        cardBackUI.GetComponent<Image>() = cardImage;
        if (cardImage == null)
        {
            Debug.LogError("Image component not found on cardBackUI GameObject!");
            return;
        }

        imageNumber = 0;
        SetCardBack(imageNumber); // Set the initial card back
    }
*/

    void Start()
    {
        imageNumber = 0;
        cardSprite = backImages[imageNumber];
        //Fetch the Image from the GameObject
        cardImage = cardBackUI.GetComponent<Image>();
    }

    public void ChangeImage()
    {
        imageNumber = (imageNumber + 1) % backImages.Count; // Cycle through the images
        Debug.Log($"Changing card back to image index {imageNumber}");
        SetCardBack(imageNumber);
    }

    public void SetCardBack(int imageIndex)
    {
        //   cardImage = cardBackUI.GetComponent<Image>();

        if (imageIndex < 0 || imageIndex >= backImages.Count)
        {
            Debug.LogWarning("Invalid image index. Cannot set card back.");
            return;
        }

        if (backImages[imageIndex] == null)
        {
            Debug.LogError($"Sprite at index {imageIndex} is null!");
            return;
        }

        cardSprite = backImages[imageIndex];
        cardImage.sprite = cardSprite; // Update the GameObject's Image
        Debug.Log("Card back successfully updated!");
    }
}

/*
public GameObject cardBackUI;
public Sprite currentImage;
public Image cardImage;
public List<Sprite> backImages = new List<Sprite>();

[SerializeField] private int imageNumber = 0;


private void Start()
{
    cardImage = cardBackUI.GetComponent<Image>(); // Get the image component
    imageNumber = 0;
    SetCardBack(imageNumber);
}

public void ChangeImage()
{
    imageNumber = (imageNumber + 1) % backImages.Count; // Cycle through images
    SetCardBack(imageNumber);
}

public void SetCardBack(int imageIndex)
{
    // Ensure the index is within bounds
    if (imageIndex < 0 || imageIndex >= backImages.Count)
    {
        Debug.LogWarning("Invalid image index");
        return;
    }

    currentImage = backImages[imageIndex]; // Update currentImage to the selected sprite
    cardImage.sprite = currentImage; // Update the card's image to the new sprite
}
/*

public void ChangeImage()
{
    imageNumber++; //go to next image
    SetCardBack(imageNumber);
}

public void SetCardBack(int imageIndex)
{
   currentImage = backImages[imageIndex];
   cardImage.sprite = currentImage;
}
*/