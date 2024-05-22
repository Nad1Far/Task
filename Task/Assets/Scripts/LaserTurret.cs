using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : MonoBehaviour
{
    public GameObject Laser;

    public float StartLaserTimer;
    private float LaserTimer; //Время действия лазера
    public float StartTimerOfNothing;
    private float TimerOfNothing; //Время бездейсвия лазера


    void Update()
    {
        if (Laser.activeSelf == true)
        {
            LaserTimer -= Time.deltaTime;
            if (LaserTimer <= 0)
            {
                Laser.SetActive(false);
                
            }
        }

        else
        {
            TimerOfNothing -= Time.deltaTime;
            if(TimerOfNothing <= 0)
            {
                Laser.SetActive(true);
                
                LaserTimer = StartLaserTimer;
                TimerOfNothing = StartTimerOfNothing;
            }
        }
    }
}
