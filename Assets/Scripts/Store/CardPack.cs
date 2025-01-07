using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPack : MonoBehaviour
{
    [SerializeField] private CardPackScriptableobject ScriptableObject;
    public Store store;
    public ParticleSystem buttonParticles;
    public CoinCounter coinCounter;


    public void PurchaseCardPoints()
    {
        if (store.player.Points >= ScriptableObject.costInPoints) // if player has enough points
        {
            buttonParticles.Play();

            // remove the points from the player
            store.player.Points -= ScriptableObject.costInPoints;
            Debug.Log($"your sum points:{store.player.Points}");

            // add the pack cards to the deck
            for (int i = 0; i < ScriptableObject.cardsInPack; i++)
            {
                GameObject cardPrefab = GeneralDeck.instance.GetRandomCard();
                GameObject card = Instantiate(cardPrefab, Vector2.zero, Quaternion.identity);

                // Card card = ScriptableObject.packCards[i];
                // instantiate card and set parent it to the playerdeck
                // GameManager.instance.CreateCard(card, store.playerDeck.transform);

                card.transform.SetParent(store.playerDeck.transform);
                card.GetComponent<RectTransform>().localScale = Vector3.one;
                card.SetActive(false);
                store.playerDeck.cards.Add(card.GetComponent<Card>());

                Debug.Log($"{cardPrefab.name} added to you deck");
                coinCounter.UpdatePoints(store.player.Points);
            }
        }
        else if (store.player.Points < ScriptableObject.costInPoints)
        {
            Debug.Log("not enough point!");
        }
    }
}