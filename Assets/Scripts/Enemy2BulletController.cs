using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2BulletController : MonoBehaviour
{
    public Transform bulletSpawnpoint;
    public GameObject bulletPrefab;
    public GameObject bulletUpPrefab;
    public GameObject bulletDownPrefab;
    public Enemy2Controller enemy2Controller;

    public float Enemy1AbsDelay = 1;
    private float relDelay = 0;
    public float Enemy1Damage = 1;
    private float angle;

    private void Start() 
    {
        angle = 45;    
    }

    private void FixedUpdate()
    {
        if (enemy2Controller.phase1 == false) {
            if (relDelay <= 0) {
                Instantiate(bulletPrefab, bulletSpawnpoint.position, transform.rotation);
                Instantiate(bulletUpPrefab, bulletSpawnpoint.position, Quaternion.Euler(new Vector3(0, 0, - angle)));
                Instantiate(bulletDownPrefab, bulletSpawnpoint.position, Quaternion.Euler(new Vector3(0, 0, angle)));
                relDelay = Enemy1AbsDelay;
            }
            relDelay -= 1;
        }
    }
}
//https://www.youtube.com/watch?v=vkKulG71Yzo