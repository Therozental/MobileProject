using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCardPack", menuName = "ScriptableObject/CardPack")]
public class CardPackScriptableobject : ScriptableObject
{
    public int costInPoints; // Cost in points
  //  public List<Card> packCards; // List of cards in the pack
    public int cardsInPack;


}