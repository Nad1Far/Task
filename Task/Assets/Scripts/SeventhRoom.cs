using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeventhRoom : MonoBehaviour
{
    public GameObject Player;
    public GameObject Door;
    public GameObject DoorInDoor;
    public GameObject SignE;
    public GameObject Button;

    public bool ButtonIs = false;
    public float Distance;
    public float targetYAngle;
    public float rotateTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(Player.transform.position, transform.position) <= Distance && Button.GetComponent<Button>().ButtonIs == true)
            {
                StartCoroutine(RotateObjectSmoothly());
                SignE.SetActive(false);
                Door.GetComponent<BoxCollider>().enabled = false;
                ButtonIs = true;
            }
        }

        if (Vector3.Distance(Player.transform.position, transform.position) <= Distance && ButtonIs == false)
        {
            SignE.SetActive(true);
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
