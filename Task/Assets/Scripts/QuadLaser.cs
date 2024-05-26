using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadLaser : MonoBehaviour
{
    public float Speed;
    public float targetYAngle;

    void Update()
    {
        transform.RotateAround(transform.position, transform.up, 1 * Speed);
    }

}