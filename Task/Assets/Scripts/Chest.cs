using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest : MonoBehaviour
{
    public GameObject WinText;
    public GameObject SignE;
    public GameObject Player;

    public bool ChestIs = false;
    public float Distance;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(Player.transform.position, transform.position) <= Distance)
            {
                SignE.SetActive(false);
                ChestIs = true;
                WinText.SetActive(true);
                Player.GetComponent<PlayerController>().enabled = false;
                Player.GetComponent<CameraController>().enabled = false;
            }
        }


        if (Vector3.Distance(Player.transform.position, transform.position) <= Distance && ChestIs == false)
        {
            SignE.SetActive(true);
        }

        if (Vector3.Distance(Player.transform.position, transform.position) >= Distance)
        {
            SignE.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && WinText.activeSelf == true)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Menu");
        }

    }
}
