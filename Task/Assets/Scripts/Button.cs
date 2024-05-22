using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    
    Renderer lr;

    public GameObject Player;
    public bool ButtonIs = false;
    public float Distance; 

    void Start()
    {
        lr = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(Player.transform.position, transform.position) <= 20)
            {
                ButtonIs = true;
                lr.material.color = Color.green;
            }
           
        }
    }
}
