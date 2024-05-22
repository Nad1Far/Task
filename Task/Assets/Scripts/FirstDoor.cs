using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDoor : MonoBehaviour
{

    public GameObject FirstBut;
    public GameObject SecondBut;
    public GameObject Door;

    private bool FirstButIsPressed = false;
    private bool SecondButIsPressed = false;


    void Update()
    {
        if (FirstBut.GetComponent<Button>().ButtonIs == true)
        {
            FirstButIsPressed = true;
        }

        if (SecondBut.GetComponent<Button>().ButtonIs == true)
        {
            SecondButIsPressed = true;
        }

        if (FirstButIsPressed == true && SecondButIsPressed == true)
        {
            Door.transform.position = new Vector3(0, 0, 0);
        }
    }

}
