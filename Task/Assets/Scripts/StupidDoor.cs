using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidDoor : MonoBehaviour
{

    public GameObject Player;
    public GameObject SignE;
    public GameObject Key;

    public float Distance;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(Player.transform.position, transform.position) <= Distance && Key.GetComponent<KeyScript>().KeyIs == true)
            {
                SignE.transform.position = new Vector3(100, 100, 100);
                SignE.SetActive(false);
                gameObject.SetActive(false);
                Key.transform.position = new Vector3(100, 100, 100);
                Key.SetActive(false);
                Player.GetComponent<Arms>().RightArmClear = true;
            }
        }

        if (Vector3.Distance(Player.transform.position, transform.position) <= Distance)
        {
            SignE.SetActive(true);
        }

        else
        {
            SignE.SetActive(false);
        }

        if (Key.GetComponent<KeyScript>().KeyIs == false)
        {
            SignE.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            SignE.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
