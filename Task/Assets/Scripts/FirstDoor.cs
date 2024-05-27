using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDoor : MonoBehaviour
{
    public AudioSource DoorOpening;

    public GameObject Player;
    public GameObject FirstBut;
    public GameObject SecondBut;
    public GameObject Door;
    public GameObject DoorInDoor;
    public GameObject SignE;

    public float Distance;
    public float targetYAngle;
    public float rotateTime;

    private bool DoorIs = false;
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



        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(Player.transform.position, Door.transform.position) <= Distance)
            {
                if (FirstButIsPressed == true && SecondButIsPressed == true)
                {
                    StartCoroutine(RotateObjectSmoothly());
                    Door.GetComponent<BoxCollider>().enabled = false;
                    DoorOpening.Play();
                    SignE.SetActive(false);
                    DoorIs = true;
                }
            }
        }

        if (Vector3.Distance(Player.transform.position, Door.transform.position) <= Distance && DoorIs == false)
        {
            SignE.SetActive(true);

            if (FirstButIsPressed == true && SecondButIsPressed == true)
            {
                SignE.GetComponent<Renderer>().material.color = Color.white;
            }
            else
            {
                SignE.GetComponent<Renderer>().material.color = Color.red;
            }
        }
        if (Vector3.Distance(Player.transform.position, Door.transform.position) >= Distance)
        {
            SignE.SetActive(false);
        }

    }


    IEnumerator RotateObjectSmoothly()
    {
        Quaternion startRotation = DoorInDoor.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(DoorInDoor.transform.rotation.x, targetYAngle, DoorInDoor.transform.rotation.z);

        float elapsedTime = 0f;

        while (elapsedTime < rotateTime)
        {
            DoorInDoor.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / rotateTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        DoorInDoor.transform.rotation = targetRotation;
    }

}
