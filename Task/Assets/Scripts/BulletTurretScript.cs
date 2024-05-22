﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurretScript : MonoBehaviour
{
    public GameObject Bullet;

    public float StartTimeBtwSpawn;
    public int n;


    private float TimeBtwSpawn;


    private void Start()
    {
        TimeBtwSpawn = StartTimeBtwSpawn;
    }


    private void Update()
    {
   
        if (TimeBtwSpawn<=0)
        {
            Instantiate(Bullet, new Vector3(transform.position.x + n, transform.position.y, transform.position.z), transform.rotation);
            TimeBtwSpawn = StartTimeBtwSpawn;
        }
        else
        {
            TimeBtwSpawn -= Time.deltaTime;
        }
       

    }
}