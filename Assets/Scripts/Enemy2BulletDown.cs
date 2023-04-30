using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2BulletDown : MonoBehaviour
{
    public float vEnemy1Bullet;
    private Rigidbody2D rb;
    public GameObject enemy2;
    //public Enemy2BulletController enemy2BulletController;
    public VariableManager variableManager;


    public float angle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        variableManager = GameObject.Find("VariableManager").GetComponent<VariableManager>();
        angle = variableManager.Enemy2Angle;
        rb.velocity = new Vector2 (- Mathf.Cos(angle * Mathf.Deg2Rad) * vEnemy1Bullet,- Mathf.Sin(angle * Mathf.Deg2Rad) * vEnemy1Bullet);
    }

    void Update() 
    {
        if (rb.transform.position.x < - 11.72 || rb.transform.position.y > 10 || rb.transform.position.y < - 10) {
            Destroy(gameObject);
        }   
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Destroy(gameObject);
        }
    }
}
//https://www.youtube.com/watch?v=mkErt53EEFY
