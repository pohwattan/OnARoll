using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAdder : Perk
{
    public override float SpawnPercentage => 0.02f;


    public override void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        EventManager.TriggerTimerAdderCollected();
    }
}
