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
            if (Vector3.Distance(Player.transform.position, transform.position) <= Distance)
            {
                KeyIs = true;
                gameObject.transform.position = new Vector3(100, 100, 100);
                SignE.SetActive(false);
            }
        }

            if (Vector3.Distance(Player.transform.position, transform.position) <= Distance && KeyIs == false)
            {
                SignE.SetActive(true);
            }
            else
            {
                SignE.SetActive(false);
            }
        
    }
}
