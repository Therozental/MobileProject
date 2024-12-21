using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBar : MonoBehaviour
{
    // public Player _progressBar;
   // public int IncreasedValue = 5;
    public TextMeshProUGUI ValueText;
    public Player _player;
    
    public void Update()
    {
        ValueText.text = _player.progressBar.value.ToString() + "/100";
        
    }
    
}
