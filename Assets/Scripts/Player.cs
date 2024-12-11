using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public int Points = 0;
    public int Exp = 0;
    public int MaxExp = 100;
    public int Level = 0;

    [SerializeField] private Transform playerPile;

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
        IncreaseMaxExp();
        ResetExp();
    }

    private int ResetExp()
    {
        return Exp = 0;
    }

    private int IncreaseMaxExp()
    {
        int levelInt = Level * 5; //get the int for the player level and multiply by 5
        MaxExp += levelInt; // add the number to the exp
        Debug.Log($"max exp increased to {MaxExp}");
        return MaxExp;
    }
}