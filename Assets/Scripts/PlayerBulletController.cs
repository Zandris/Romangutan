using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    public Transform bulletSpawnpoint;
    public GameObject bulletPrefab;

    private bool Space = false;

    public float absDelay = 1;
    private float relDelay = 0;
    public float damage = 1;

    private void FixedUpdate()
    {
        if (Space) {
            if (relDelay <= 0) {
                Instantiate(bulletPrefab, bulletSpawnpoint.position, transform.rotation);
                relDelay = absDelay;
            }
            relDelay -= 1;
        }
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space)) {
            //F = true;
            //Instantiate(bulletPrefab, bulletSpawnpoint.position, transform.rotation);
        //}
        if (Input.GetKeyDown(KeyCode.Space)) {
            Space = true;
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            Space = false;
        }
    }
}
//https://www.youtube.com/watch?v=vkKulG71Yzo