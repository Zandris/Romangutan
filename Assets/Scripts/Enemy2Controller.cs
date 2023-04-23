using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject medKitPrefab;
    public GameObject upgradePointPrefab;
    public PlayerController playerController;
    public GameObject enemySpawner;

    public float vEnemy2 = 1;
    private float chance;

    public float health = 5;

    public bool phase1 = true;

    private void Start() 
    {
        enemySpawner = GameObject.Find("Enemy Spawner");
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        enemySpawner.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        phase1 = true;
    }

    private void Update()
    {
        if (rb.transform.position.x > 8 && phase1 == true) {
            rb.velocity = new Vector2 (- vEnemy2, 0);
        } else if (phase1 == true)
        {
            rb.velocity = new Vector2 (0, 0);
            phase1 = false;
        }
    }

    private void FixedUpdate() 
    {
        if (phase1 == false && rb.transform.position.y <= playerController.rb.transform.position.y + 0.01 && rb.transform.position.y >= playerController.rb.transform.position.y - 0.01) {
            rb.velocity = new Vector2 (0, 0);
        } else if (phase1 == false && rb.transform.position.y < playerController.rb.transform.position.y) {
            rb.velocity = new Vector2 (0, ((playerController.rb.transform.position.y - rb.transform.position.y) * (playerController.rb.transform.position.y - rb.transform.position.y) * (playerController.rb.transform.position.y - rb.transform.position.y) * (playerController.rb.transform.position.y - rb.transform.position.y)));
        } else if (phase1 == false && (rb.transform.position.y > playerController.rb.transform.position.y)) {
            rb.velocity = new Vector2 (0, - ((playerController.rb.transform.position.y - rb.transform.position.y) * (playerController.rb.transform.position.y - rb.transform.position.y) * (playerController.rb.transform.position.y - rb.transform.position.y) * (playerController.rb.transform.position.y - rb.transform.position.y)));
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "PlayerBullet") {
            health -= 1;
        }

        if (health == 0) {
            Destroy(gameObject);
            enemySpawner.SetActive(true);
            Instantiate(upgradePointPrefab, new Vector2 (rb.transform.position.x + 1, rb.transform.position.y), transform.rotation);
            Instantiate(medKitPrefab, new Vector2 (rb.transform.position.x - 1, rb.transform.position.y), transform.rotation);
        }
    }
}
