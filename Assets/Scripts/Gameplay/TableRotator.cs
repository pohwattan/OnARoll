using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TableRotator : MonoBehaviour
{
    public float rotationSpeed = 20;
    public int angularLimit = 20;

    public GameObject ball;
    public float raycastDistance = 1.0f;


    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(ball.transform.position, Vector3.down, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Table"))
            {
                RotateFloor();
            }
        }
    }
    
    // Update is called once per frame
    void RotateFloor()
    {
        // Rotate the table around x and z axis
        float newZAxisRotation = transform.rotation.eulerAngles.z;
        float newXAxisRotation = transform.rotation.eulerAngles.x;
        if(Input.GetKey(KeyCode.LeftArrow))
            newZAxisRotation += rotationSpeed * Time.deltaTime;
        if(Input.GetKey(KeyCode.RightArrow))
            newZAxisRotation -= rotationSpeed * Time.deltaTime;
        if(Input.GetKey(KeyCode.UpArrow))
            newXAxisRotation += rotationSpeed * Time.deltaTime;
        if(Input.GetKey(KeyCode.DownArrow))
            newXAxisRotation -= rotationSpeed * Time.deltaTime;
        
        newZAxisRotation = (newZAxisRotation<90 && newZAxisRotation>angularLimit) ? angularLimit : newZAxisRotation;
        newZAxisRotation = (newZAxisRotation>90 && newZAxisRotation<360-angularLimit) ? 360-angularLimit : newZAxisRotation;

        newXAxisRotation = (newXAxisRotation<90 && newXAxisRotation>angularLimit) ? angularLimit : newXAxisRotation;
        newXAxisRotation = (newXAxisRotation>90 && newXAxisRotation<360-angularLimit) ? 360-angularLimit : newXAxisRotation;
        
        Vector3 newRotationEulars = new Vector3(newXAxisRotation, transform.rotation.eulerAngles.y, newZAxisRotation);
        transform.rotation = Quaternion.Euler(newRotationEulars);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball")) 
        {
            EventManager.TriggerBoundaryEntered();
        }
    }
}