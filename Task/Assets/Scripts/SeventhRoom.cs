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

    public bool DoorIs = false;
    public bool ButtonIs = false;

    public float Distance;
    public float targetYAngle;
    public float rotateTime;

    void Update()
    {
        if (Button.GetComponent<Button>().ButtonIs == true)
        {
            ButtonIs = true;
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(Player.transform.position, Door.transform.position) <= Distance && ButtonIs == true)
            {
                StartCoroutine(RotateObjectSmoothly());
                SignE.SetActive(false);
                Door.GetComponent<BoxCollider>().enabled = false;
                DoorIs = true;
            }
        }

        if (Vector3.Distance(Player.transform.position, Door.transform.position) <= Distance && ButtonIs == false)
        {
            SignE.SetActive(true);
            SignE.GetComponent<Renderer>().material.color = Color.red;
        }
        if (Vector3.Distance(Player.transform.position, Door.transform.position) <= Distance && ButtonIs == true && DoorIs == false)
        {
            SignE.SetActive(true);
            SignE.GetComponent<Renderer>().material.color = Color.white;
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
