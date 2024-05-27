using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDoor : MonoBehaviour
{
    public AudioSource DoorOpening;

    public GameObject FirstBut;
    public GameObject SecondBut;
    public GameObject Door;
    public GameObject DoorInDoor;

    public float targetYAngle;
    public float rotateTime;

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
            StartCoroutine(RotateObjectSmoothly());
            Door.GetComponent<BoxCollider>().enabled = false;
            DoorOpening.Play();
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
