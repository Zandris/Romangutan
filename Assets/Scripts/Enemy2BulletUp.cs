using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2BulletUp : MonoBehaviour
{
    public float vEnemy1Bullet;
    private Rigidbody2D rb;
    public GameObject enemy2;
    public Enemy2BulletController enemy2BulletController;

    public float angle;

    void Start()
    {
        enemy2 = GameObject.FindWithTag("Enemy");
        
        //if (enemy2 == null) {
           // Debug.Log("GameObject.Find(Enemy 2); == null");
        //}

        enemy2BulletController = enemy2.GetComponent<Enemy2BulletController>();

        //if (enemy2BulletController == null) {
            //Debug.Log("enemy2.GetComponent<Enemy2BulletController>(); == null");
        //}

        angle = enemy2BulletController.angle;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2 (- Mathf.Cos(angle * Mathf.Deg2Rad) * vEnemy1Bullet, Mathf.Sin(angle * Mathf.Deg2Rad) * vEnemy1Bullet);
    }


    void Update() 
    {
        //if (rb.transform.position.x < - 11.72 || rb.transform.position.y > 10 || rb.transform.position.y < - 10) {
            //Destroy(gameObject);
        //}   
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" ){//|| rb.transform.position.y > 10 || rb.transform.position.y < - 10) {
            Destroy(gameObject);
        }
        //Destroy(gameObject);
    }
}
//https://www.youtube.com/watch?v=mkErt53EEFY
