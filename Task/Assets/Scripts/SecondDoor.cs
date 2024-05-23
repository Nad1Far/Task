using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondDoor : MonoBehaviour
{
    public GameObject Player;
    public GameObject FirstKey;
    public GameObject Door;
    public GameObject SignE;

    public float Distance;

    public bool FirstKeyIsCollected = false;
    public bool SecondKeyIsCollected = false;


    void Update()
    {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Vector3.Distance(Player.transform.position, Door.transform.position) <= Distance && Player.GetComponent<Arms>().RightArmClear == false && FirstKey.GetComponent<KeyScript>().KeyIs == true)
                {
                    FirstKey.SetActive(false);
                    Player.GetComponent<Arms>().RightArmClear = true;
                    FirstKeyIsCollected = true;
                    SignE.SetActive(false);

                }
            }


        if (Vector3.Distance(Player.transform.position, Door.transform.position) <= Distance)
        {
            SignE.SetActive(true);

        }
        else
        {
            SignE.SetActive(false);
        }

        if (FirstKeyIsCollected == true)
        {
            Door.SetActive(false);
            SignE.transform.position = new Vector3(100, 100, 100);
            SignE.SetActive(false);
        }
    }
}
