using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Deck", menuName = "ScriptableObject/Deck")]
public class DeckScriptableObject : ScriptableObject
{
  [SerializeField] private List<GameObject> deck = new List<GameObject>();
}
