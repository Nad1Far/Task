using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustDoor : MonoBehaviour
{
    public GameObject Player;
    public GameObject DoorInDoor;
    public GameObject SignE;

    public float targetYAngle;
    public float rotateTime;
    public float Distance;
    public bool DoorIs = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(Player.transform.position, transform.position) <= Distance)
            {
                StartCoroutine(RotateObjectSmoothly());
                SignE.SetActive(false);
                DoorIs = true;
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }

        if (Vector3.Distance(Player.transform.position, transform.position) <= Distance && DoorIs == false)
        {
            SignE.SetActive(true);
        }
        else
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
