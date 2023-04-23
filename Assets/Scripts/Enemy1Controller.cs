using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject medKitPrefab;
    public GameObject upgradePointPrefab;

    public float vEnemy1 = 1;
    private float chance;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2 (- vEnemy1, 0f);
    }

    private void Update()
    {
        if (transform.position.x < - 12) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        chance = Random.Range(0f, 10f);
        if (chance >= 0  && chance < 5 && other.gameObject.tag == "PlayerBullet") {
            Instantiate(upgradePointPrefab, rb.position, transform.rotation);
            //Debug.Log("medkit");
        } else if (chance > 5 && chance <= 8 && other.gameObject.tag == "PlayerBullet") {
            Instantiate(medKitPrefab, rb.position, transform.rotation);
            //Debug.Log("upgradepoint");
        }

        if (other.gameObject.tag == "PlayerBullet") {
            Destroy(gameObject);
        }
    }
}
