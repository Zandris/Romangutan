using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1BulletController : MonoBehaviour
{
    public Transform bulletSpawnpoint;
    public GameObject bulletPrefab;

    private bool state = true;

    public float Enemy1AbsDelay = 1;
    private float relDelay = 0;
    public float Enemy1Damage = 1;

    private void FixedUpdate()
    {
        if (state) {
            if (relDelay <= 0) {
                Instantiate(bulletPrefab, bulletSpawnpoint.position, transform.rotation);
                relDelay = Enemy1AbsDelay;
            }
            relDelay -= 1;
        }
    }
}
//https://www.youtube.com/watch?v=vkKulG71Yzo