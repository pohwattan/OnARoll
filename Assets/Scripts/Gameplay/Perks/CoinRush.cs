using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRush : Perk
{
    public override float SpawnPercentage => 0.03f;


    public override void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        EventManager.TriggerCoinRushCollected();
    }
}
