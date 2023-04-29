using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public HealthBar healthBar;
    public ShieldBar shieldBar;

    public GameObject deathScreen;

    public GameObject Enemy2;


    public int maxHealth = 100;
    public int currentHealth;
    public int maxShield = 50;
    public int currentShield;
    public int shieldRechargeRate = 1;
    public int upgradePoints = 0;
    
    public int shieldRechargeCooldown = 2;
    private float updateTimer;  

    private bool A = false;
    private bool W = false;
    private bool S = false;
    private bool D = false;

    public float v = 0.12f;
    private float x = 0;
    private float y = 0;

    private void Start() 
    {
        Enemy2 = GameObject.Find("Enemy2");
        Destroy(Enemy2);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        currentShield = maxShield;
        shieldBar.SetMaxShield(maxShield);

        deathScreen.SetActive(false);

        //Debug.Log("current shield: " + currentShield + " " + "max shield: " + maxShield);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.transform.position = new Vector2 (-5, 10);
        Time.timeScale = 1f;
    }

    private void FixedUpdate()
    {
        if (A == true && rb.transform.position.x >= - 9.72) { //x: 9.72, y: 5.28
            x -= v;
        }
        
        if (W == true && rb.transform.position.y <= 5.27) {
            y += v;
        }

        if (S == true && rb.transform.position.y >= - 5.27) {
            y -= v;
        }
    
        if (D == true && rb.transform.position.x <= 9.72) {
            x += v;
        }

        rb.transform.position = new Vector2 (x, y);
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.A)) {
            A = true;
        }
        if (Input.GetKeyUp(KeyCode.A)) {
            A = false;
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            W = true;
        }
        if (Input.GetKeyUp(KeyCode.W)) {
            W = false;
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            S = true;
        }
        if (Input.GetKeyUp(KeyCode.S)) {
            S = false;
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            D = true;
        }
        if (Input.GetKeyUp(KeyCode.D)) {
            D = false;
        }

        if (currentShield <= 0) {
            shieldBar.shieldState = false;
        } else {
            shieldBar.shieldState = true;
        }

        if (currentShield != maxShield) {
            updateTimer -= Time.deltaTime;

            if(updateTimer <= 0) {
                StartCoroutine("RechargeShield");
                //Debug.Log("current shield: " + currentShield + " " + "max shield: " + maxShield);
                updateTimer = shieldRechargeCooldown;
            }

        }

        if (currentShield >= maxShield) {
            StopCoroutine("RechargeShield");
        }
        //Debug.Log("current shield: " + currentShield + " " + "max shield: " + maxShield);
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        //Debug.Log("PlayerController: maxhealth: " + maxHealth + " health: " + currentHealth);

        if (currentHealth <= 0) {
            deathScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (shieldBar.shieldState == false && other.gameObject.tag == "EnemyBullet")
        {
            currentHealth -= 1000;
            healthBar.SetHealth(currentHealth);
        } else if (other.gameObject.tag == "EnemyBullet") {
            currentShield -= 1000;    
            shieldBar.SetShield(currentShield);
        } else if (other.gameObject.tag == "MedKit") {
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
        } else if (other.gameObject.tag == "Enemy") {
            currentHealth = 0;
            healthBar.SetHealth(currentHealth);
        } else if (other.gameObject.tag == "UpgradePoint") {
            upgradePoints += 1;
        }
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyBullet") {
            StopCoroutine("RechargeShield");
        }
    }

    IEnumerator RechargeShield() 
    {
            for (float shield = currentShield; currentShield <= maxShield; currentShield += shieldRechargeRate) {
                shieldBar.SetShield(currentShield + shieldRechargeRate);
                yield return new WaitForSeconds(Time.deltaTime);
            }

            shieldBar.SetShield(currentShield);
    }

}
//tutorialok

//https://www.youtube.com/watch?v=vkKulG71Yzo
//https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=143s
//https://youtu.be/rD3orKDCM50
//https://www.youtube.com/watch?v=KE9BHGgVP4A
//https://forum.unity.com/threads/converting-float-to-integer.27511/
//https://www.youtube.com/watch?v=9dYDBomQpBQ
//http://plbm.com/?p=248
//http://plbm.com/?p=221
