using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class CardBack : MonoBehaviour
{
    public Image currentImage;
    public List<Sprite> backImages = new List<Sprite>();

    [SerializeField] private int imageNumber = 0;


    private void Start()
    {
        imageNumber = 0;
        currentImage.sprite = backImages[imageNumber]; // current image is at 0
    }

    public void ChangeImage()
    {
        imageNumber++;
        SetCardBack(imageNumber);
    }

    public void SetCardBack(int imageIndex)
    {
        currentImage.sprite = backImages[imageIndex];
    }

    public int increaseIndex()
    {
        imageNumber++;
        return imageNumber;
    }
}