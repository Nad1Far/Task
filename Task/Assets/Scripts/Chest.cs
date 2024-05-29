using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    public GameObject SignE;
    public GameObject Player;

    public bool ChestIs = false;
    public float Distance;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(Player.transform.position, transform.position) <= Distance)
            {
                SignE.SetActive(false);
                ChestIs = true;
            }
        }


        if (Vector3.Distance(Player.transform.position, transform.position) <= Distance && ChestIs == false)
        {
            SignE.SetActive(true);
        }

        if (Vector3.Distance(Player.transform.position, transform.position) >= Distance)
        {
            SignE.SetActive(false);
        }
    }
}
