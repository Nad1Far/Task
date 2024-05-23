using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowPick : MonoBehaviour
{
    public GameObject SignE;
    public GameObject Player;

    private bool BowIs = false;
    public float Distance;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(Player.transform.position, transform.position) <= Distance)
            {
                BowIs = true;
                gameObject.transform.position = new Vector3(100, 100, 100);
                SignE.SetActive(false);
            }
        }

        if (Vector3.Distance(Player.transform.position, transform.position) <= Distance && BowIs == false)
        {
            SignE.SetActive(true);
        }
        else
        {
            SignE.SetActive(false);
        }

    }
}

