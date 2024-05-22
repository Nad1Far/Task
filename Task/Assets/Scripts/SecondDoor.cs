using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondDoor : MonoBehaviour
{
    public GameObject FirstKey;
    public GameObject SecondKey;
    public GameObject Door;

    private bool FirstKeyIsCollected = false;
    private bool SecondKeyIsCollected = false;


    void Update()
    {
        if (FirstKey.GetComponent<KeyScript>().KeyIs == true)
        {
            FirstKeyIsCollected = true;
        }

        if (SecondKey.GetComponent<KeyScript>().KeyIs == true)
        {
            SecondKeyIsCollected = true;
        }

        if (FirstKeyIsCollected == true && SecondKeyIsCollected == true)
        {
            Door.transform.position = new Vector3(0, 0, 0);
        }
    }
}
