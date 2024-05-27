using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    
    Renderer lr;

    public AudioSource ButSound;

    public GameObject SignE;
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
            if (Vector3.Distance(Player.transform.position, transform.position) <= Distance)
            {
                ButtonIs = true;
                lr.material.color = Color.green;
                SignE.SetActive(false);
                ButSound.Play();
            }
           
        }
        if (Vector3.Distance(Player.transform.position, transform.position) <= Distance && ButtonIs == false)
        {
            SignE.SetActive(true);
        }
        else
        {
            SignE.SetActive(false);
        }
    }
}
