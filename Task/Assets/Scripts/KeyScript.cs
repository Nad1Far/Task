using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public bool KeyIs = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            KeyIs = true;
            gameObject.transform.position = new Vector3(100, 100, 100);
        }
    }
}
