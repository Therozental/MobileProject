using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public int Points = 0;
    public int Exp = 0;
    public int Level = 1;


    public void GetExp()
    {
        int expPoints = Random.Range(5, 20);
        Exp += expPoints;

        if (Exp >= 100)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Level++;
        ResetExp();
    }

    private void ResetExp()
    {
        Exp = 0;
    }
}