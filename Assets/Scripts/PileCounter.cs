using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PileCounter : MonoBehaviour
{
    public TextMeshProUGUI NumberText;

    public void ChangeNumber(int Number)
    {
        NumberText.text = Number.ToString();
    }
    void Update()
    {
    //    ValueText.text = progressBar.value.ToString() + "/" + progressBar.maxValue.ToString();
       // NumberText.text =  + "Cards Left";
    }
}
