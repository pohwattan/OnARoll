using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkRotator : MonoBehaviour
{
    public float rotationSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,rotationSpeed,0,Space.Self);
    }
}
