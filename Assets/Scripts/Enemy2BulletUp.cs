using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2BulletUp : MonoBehaviour
{
    public float vEnemy1Bullet;
    private Rigidbody2D rb;

    [SerializeField]
    private float angle = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2 (- Mathf.Cos(angle * Mathf.Deg2Rad) * vEnemy1Bullet, Mathf.Sin(angle * Mathf.Deg2Rad) * vEnemy1Bullet);
    }

    void Update() 
    {
        if (rb.transform.position.x < - 11.72 || rb.transform.position.y > 10 || rb.transform.position.y < - 10) {
            Destroy(gameObject);
        }   
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" ){//|| rb.transform.position.y > 10 || rb.transform.position.y < - 10) {
            Destroy(gameObject);
        }
        //Destroy(gameObject);
    }
}
//https://www.youtube.com/watch?v=mkErt53EEFY
