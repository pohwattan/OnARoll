using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableRepair : Perk
{
    public override float SpawnPercentage => 0.025f;


    public override void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        EventManager.TriggerTableRepairCollected();
    }
}
