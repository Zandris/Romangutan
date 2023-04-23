using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float vBullet;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2 (vBullet, 0f);
    }

    void Update() 
    {
        if (rb.transform.position.x > 11.72) {
            Destroy(gameObject);
        }   
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Enemy") {
            Destroy(gameObject);
        }
    }

    //destroy bullet when colliding with enemy
}
//https://www.youtube.com/watch?v=vkKulG71Yzo
