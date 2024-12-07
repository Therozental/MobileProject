using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileClick : MonoBehaviour
{
    public Round round;
    void OnMouseDown()
    {
        round.StartRound();
    }
}
