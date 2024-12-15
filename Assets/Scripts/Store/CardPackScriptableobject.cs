using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCardPack", menuName = "ScriptableObject/CardPack")]
public class CardPackScriptableobject : ScriptableObject
{
    // public string packName; // Name of the pack
    // public int numberOfCards; // Number of cards in the pack
    public int costInPoints; // Cost in points
    public int costInCash; // Cost in cash
    public List<Card> packCards; // List of cards in the pack
}