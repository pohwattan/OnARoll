using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    private Vector3 initialLocation;
    private Vector3 initialVelocity;
    private Rigidbody rigidBody;
    public float jumpForce = 5.0f;
    private bool isTouchingTable = false;
    public AudioClip ballRollClip, ballHitClip;
    private AudioSource tableCollisionAudioSource;
    public AudioClip coinClip;
    private AudioSource effectsAudioSource;
    public GameObject moneyParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        initialLocation = rigidBody.transform.position;
        initialVelocity = rigidBody.velocity;
        tableCollisionAudioSource = gameObject.AddComponent<AudioSource>();
        effectsAudioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //reset the ball by dropping it to initial location
        if(Input.GetKey(KeyCode.R))
        {
            rigidBody.transform.position = initialLocation;
            rigidBody.velocity = initialVelocity;
        }

        if(Input.GetKey(KeyCode.Space) && isTouchingTable)
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x,jumpForce, rigidBody.velocity.z);
        }

        tableCollisionAudioSource.volume = rigidBody.velocity.magnitude/5.0f;

        if(isTouchingTable && rigidBody.velocity!=Vector3.zero && !tableCollisionAudioSource.isPlaying)
        {
            tableCollisionAudioSource.PlayOneShot(ballRollClip);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        //ball hitting table first time, play bounce clip
        if(collision.gameObject.tag=="Table" && !isTouchingTable)
        {
            isTouchingTable = true;
            tableCollisionAudioSource.PlayOneShot(ballHitClip);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Coin")
        {
            effectsAudioSource.pitch = 1;
            effectsAudioSource.PlayOneShot(coinClip);
            Destroy(other.gameObject);
            ScoreDisplay.scoreValue++;
            Instantiate(moneyParticleSystem, other.gameObject.transform.position, Quaternion.identity, other.gameObject.transform.parent.transform);
        }
    } 

    public void OnCollisionExit(Collision collision)
    {
        isTouchingTable = false;
    }
}
