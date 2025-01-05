using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralDeck : MonoBehaviour
{
    public List<GameObject> cards = new List<GameObject>();

    public static GeneralDeck instance;

    public void Awake()
    {
        //Singletone:
        if (instance == null) // if there is no instance, we initialize it
        {
            instance = this;
        }
        else if (instance != this) // if this instance is not the original, we destroy it
        {
            Destroy(gameObject);
        }
    }

    public GameObject GetRandomCard()
    {
        int randomIndex = Random.Range(0, cards.Count);
        return cards[randomIndex];
    }
}