using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurretScript : MonoBehaviour
{
    public AudioSource ShootSound;

    public GameObject Player;
    public GameObject Bullet;
    public GameObject BulletSpawner;

    public float Distance;
    public float StartTimeBtwSpawn;
    public int n;

    private float TimeBtwSpawn;


    private void Start()
    {
        TimeBtwSpawn = StartTimeBtwSpawn;
    }


    private void Update()
    {
        BulletSpawner.transform.rotation = gameObject.transform.rotation;

        if (TimeBtwSpawn<=0)
        {
            Instantiate(Bullet, BulletSpawner.transform.position, gameObject.transform.rotation);
            TimeBtwSpawn = StartTimeBtwSpawn;

            if (Vector3.Distance(Player.transform.position, transform.position) <= Distance)
            {
                ShootSound.Play();
            }

        }
        else
        {
            TimeBtwSpawn -= Time.deltaTime;
        }
       

    }
}
