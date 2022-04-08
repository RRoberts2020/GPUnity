using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth = 10;
    public int currentHealth;

//    public HealthBar healthBar;



    public bool enemyTakesDamage;

    public bool enemyDeath;

    public AudioSource bossBackGroundSound;

    public AudioSource winSound;

    //Split enemy death
    //float randomX;
    //float randomZ;
    //public Transform trans;
    //public Transform spawnTrans;
    //public GameObject smallerEnemy;
    //private Vector3 scale1;

    void Start()
    {
        currentHealth = maxHealth;
        //        healthBar.SetMaxHealth(maxHealth);

     bossBackGroundSound.Play();

    // Gets a random point to set at the cubes position when it spawns new cubes
    //randomX = Random.Range(5f, 15f);
    //randomZ = Random.Range(10f, 20f);
    //spawnTrans.position = trans.position + new Vector3(randomX, 0, randomZ);

    //// Sets variables used to chekc the scal of the cube(s)
    //scale1 = new Vector3(0.5f, 0.5f, 0.5f);
}


    public void Update()
    {
        if (currentHealth <= 0)
        {
            enemyDeath = true;
            winSound.Play();
            bossBackGroundSound.Stop();
            Destroy(gameObject);

            //if (smallerEnemy.transform.localScale == scale1)
            //{
            //    smallerEnemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            //    Instantiate(smallerEnemy, spawnTrans.position, Quaternion.identity);
            //    Instantiate(smallerEnemy, spawnTrans.position, Quaternion.identity);
            //    Destroy(smallerEnemy);

            //}
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
//        healthBar.SetHealth(currentHealth);
    }
}
