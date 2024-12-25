using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PileClick : MonoBehaviour
{
    void OnPointerDown()
    {
        GameManager.instance.RoundPlay();
    }

    private void Update()
    {
        
    }
}