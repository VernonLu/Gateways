using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Interactive {
    public Transform exitPosition;
    public GameObject teleport;
    public AudioSource teleportAudio;
    public float forceUp;
    void Start()
    {
        //isActivated = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActivated)
        {
            collision.transform.SetPositionAndRotation(exitPosition.position, Quaternion.identity);
            teleportAudio.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, forceUp, 0f), ForceMode2D.Impulse);
    }
    public override void Activate()
    {
        isActivated = true;
        teleport.SetActive(true);
    }
}
