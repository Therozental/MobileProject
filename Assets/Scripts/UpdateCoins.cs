using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UpdateCoins : MonoBehaviour
{
    public CoinCounter coinCounter;
    public Player player;

    public async void UpdatePoints()
    {
        await Task.Delay(500);
        coinCounter.PlayAnimation();
        coinCounter.AdjustPoints(player.Points);
    }
}
