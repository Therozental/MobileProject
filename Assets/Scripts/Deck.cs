using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    public List<Card> cards = new List<Card>();
    public List<Card> DiscardPile = new List<Card>();
   // public Card topCard;

    
    public void Shuffle() // Shuffle method to randomize the order of cards in the cards.
    {
        for (int i = 0; i < cards.Count; i++)
        {
            int randomIndex = Random.Range(0, cards.Count); // Get a random index.
            (cards[i], cards[randomIndex]) = (cards[randomIndex], cards[i]); //Swap between the random index and the i
        }
        Debug.Log("Cards Shuffled");
    }

    public Card DrawTopCard()
    {
        // the top card of the deck
        Card topCard = cards[0]; 
        
        // remove the top card from the cards pile
        cards.RemoveAt(0); 
        Debug.Log($"card drawn {topCard}");
        return topCard;
        
    }
    
    // public Card PlayCard()
    // {
    //     // the top card from the deck
    //     Card currentCard = DrawTopCard();  
    //     Debug.Log($"Player card {currentCard}");
    //     return currentCard;
    // }

    public void PlayerRemove3Cards() // if both cards has the same value, take out 3 cards from each deck and try again
        {
            for (int i = 0; i < 3; i++)
            {
                Card removedPlayerCard = DrawTopCard(); //remove the first card from the player pile
                DiscardPile.Add(removedPlayerCard); // add the card to the player discard pile
                Debug.Log("Player removed 3 cards");
                
            }
            //have some cool animation each card removal
        }

        public void CPURemove3Cards()
        {
            for (int i = 0; i < 3; i++)
            {
            Card removedCpuCard = DrawTopCard(); // remove the first card from the cpu pile
            cards.Insert(cards.Count, removedCpuCard); // put the card last in the cpu deck
            Debug.Log("CPU removed 3 cards");
            }
        }
        
}