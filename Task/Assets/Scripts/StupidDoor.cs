using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidDoor : MonoBehaviour
{
    public AudioSource DoorOpening;

    public GameObject Player;
    public GameObject SignE;
    public GameObject Key;
    public GameObject DoorInDoor;

    public float targetYAngle;
    public float rotateTime;
    public float Distance;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(Player.transform.position, transform.position) <= Distance && Key.GetComponent<KeyScript>().KeyIs == true)
            {
                SignE.transform.position = new Vector3(100, 100, 100);
                SignE.SetActive(false);
                Key.transform.position = new Vector3(100, 100, 100);
                Key.SetActive(false);
                Player.GetComponent<Arms>().RightArmClear = true;
                StartCoroutine(RotateObjectSmoothly());
                GetComponent<BoxCollider>().enabled = false;
                DoorOpening.Play();
            }
        }

        if (Vector3.Distance(Player.transform.position, transform.position) <= Distance)
        {
            SignE.SetActive(true);
        }

        else
        {
            SignE.SetActive(false);
        }

        if (Key.GetComponent<KeyScript>().KeyIs == false)
        {
            SignE.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            SignE.GetComponent<Renderer>().material.color = Color.white;
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
