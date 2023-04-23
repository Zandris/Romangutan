using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float despawnTime;
    private float updateTimer;

    private void Start() 
    {
        //Debug.Log("start");
        updateTimer = despawnTime;
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2 (- 3, 0);

        //Debug.Log(rb.velocity);
    }

    void Update()
    {
        updateTimer -= Time.deltaTime;
        if(updateTimer <= 0) {
            //Debug.Log("medkit despawn");
            Destroy(gameObject);
            updateTimer = despawnTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player") {
            Destroy(gameObject);
        }
    }
}
