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
        Card topCard = cards[0];
        cards.RemoveAt(0); // remove the top card from the cards pile
        return topCard;
    }
    
    public async Task PlayCard(Card card)
    {
        await Task.Delay(100);
        card = DrawTopCard(); // remove the top card from the pile
        // _playerCard.gameObject.SetActive(true);
        Debug.Log($"Player card {card}");
        
    }

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