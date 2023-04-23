using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Bullet : MonoBehaviour
{
    public float vEnemy1Bullet;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2 (- vEnemy1Bullet, 0f);
    }

    void Update() 
    {
        if (rb.transform.position.x < - 11.72) {
            Destroy(gameObject);
        }   
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Destroy(gameObject);
        }
        //Destroy(gameObject);
    }
}
//https://www.youtube.com/watch?v=mkErt53EEFY
