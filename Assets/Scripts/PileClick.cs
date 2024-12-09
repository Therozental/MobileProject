using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PileClick : MonoBehaviour
{
    public Round round;
    
    void OnPointerDown()
    {
        round.StartRound();
        
    }
    
    
}
