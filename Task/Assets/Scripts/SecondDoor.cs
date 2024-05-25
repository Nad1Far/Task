using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondDoor : MonoBehaviour
{
    public GameObject Player;
    public GameObject FirstKey;
    public GameObject Door;
    public GameObject SignE;
    public GameObject DoorInDoor;

    public float targetYAngle;
    public float rotateTime;
    public float Distance;

    public bool FirstKeyIsCollected = false;
    public bool SecondKeyIsCollected = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(Player.transform.position, Door.transform.position) <= Distance && Player.GetComponent<Arms>().RightArmClear == false && FirstKey.GetComponent<KeyScript>().KeyIs == true)
            {
                FirstKey.SetActive(false);
                Player.GetComponent<Arms>().RightArmClear = true;
                FirstKeyIsCollected = true;
                SignE.SetActive(false);
                StartCoroutine(RotateObjectSmoothly());
                SignE.SetActive(false);
                Door.GetComponent<BoxCollider>().enabled = false;
            }
        }


        if (Vector3.Distance(Player.transform.position, Door.transform.position) <= Distance && FirstKeyIsCollected == false)
        {
            SignE.SetActive(true);
            SignE.GetComponent<Renderer>().material.color = Color.red;

        }
        else
        {
            SignE.SetActive(false);
        }

        if (Vector3.Distance(Player.transform.position, Door.transform.position) <= Distance && Player.GetComponent<Arms>().RightArmClear == false && FirstKey.GetComponent<KeyScript>().KeyIs == true)
        {
            SignE.GetComponent<Renderer>().material.color = Color.white;
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
}
