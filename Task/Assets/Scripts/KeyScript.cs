using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject SignE;

    public float Distance;
    public bool KeyIs = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(Player.transform.position, transform.position) <= Distance && Player.GetComponent<Arms>().RightArmClear == true)
            {
                KeyIs = true;
                SignE.SetActive(false);
                if (Player.GetComponent<Arms>().RightArmClear == true)
                {

                    Player.GetComponent<Arms>().RightArmClear = false;
                    
                }
            }  
        }

        if (Vector3.Distance(Player.transform.position, transform.position) <= Distance && KeyIs == false)
        {
            SignE.SetActive(true);
            if (Player.GetComponent<Arms>().RightArmClear == false)
            {
                SignE.GetComponent<Renderer>().material.color = Color.red;
            }
        }
        else
        {
            SignE.SetActive(false);
        }
        
        if (KeyIs == true && Player.GetComponent<Arms>().RightArmClear == false)
        {
            transform.rotation = Player.GetComponent<Arms>().RightArm.transform.rotation;
            transform.position = Player.GetComponent<Arms>().RightArm.transform.position;

        }
    }
}
