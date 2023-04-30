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
    public VariableManager variableManager;

    public float Enemy1AbsDelay = 1;
    private float relDelay = 0;
    public float Enemy1Damage = 1;
    public float angle;

    private void Start() 
    {
        variableManager = GameObject.Find("VariableManager").GetComponent<VariableManager>();
        angle = variableManager.Enemy2Angle;
        //angle = 10;    
    }

    private void FixedUpdate()
    {
        //finomhangoláshoz töröld ki a //-eket a következő kommentből de ne feljtsd el visszatenni a //-eket
        //angle = variableManager.Enemy2Angle;

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