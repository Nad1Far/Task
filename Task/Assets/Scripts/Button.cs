using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    Renderer lr;
    public bool ButtonIs = false;
    void Start()
    {
        lr = GetComponent<Renderer>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lr.material.color = Color.green;
            ButtonIs = true;
        }
    }
}
