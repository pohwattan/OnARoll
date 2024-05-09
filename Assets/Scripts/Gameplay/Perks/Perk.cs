using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Perk : MonoBehaviour
{
    protected float _untakenDuration = 10f;
    protected float _takenDuration = 15f;

    public virtual float SpawnPercentage { get; }

    public abstract void OnTriggerEnter(Collider other);
}
