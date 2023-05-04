using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;

    private float relTime = 0;
    public float absTime;
    //private float fps = 0;
    Vector2 spawnPoint = new Vector2 (0f, 0f);
    private float randomY = 0;
    //x: 11.52, y: 5.28

    private float lastTime;

    void Start()
    {
        lastTime = 0;
        rb = GetComponent<Rigidbody2D>();
        //Debug.Log(spawnPoint);
    }

    void Update()
    {
        if (Time.realtimeSinceStartup - lastTime > 30 && Time.timeSinceLevelLoad > 5) {
            Instantiate(enemy2Prefab, spawnPoint, transform.rotation);
            lastTime = Time.realtimeSinceStartup;
        } else if (relTime <= 0) {
            randomY = Random.Range(5.28f, -5.28f);
            spawnPoint = new Vector2 (rb.position.x, randomY);
            Instantiate(enemy1Prefab, spawnPoint, transform.rotation);
            relTime = absTime;
        }
        relTime -= Time.deltaTime;
    }
}
