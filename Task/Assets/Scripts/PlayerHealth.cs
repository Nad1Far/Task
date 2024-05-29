using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject GameOverUI;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet" || other.gameObject.tag == "Laser" || other.gameObject.tag == "Shape")
        {
            GameOverUI.SetActive(true);
            GetComponent<PlayerController>().enabled = false;
            GetComponent<CameraController>().enabled = false;

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameOverUI.activeSelf == true)
        {
            SceneManager.LoadScene("Menu");
        }
        if (Input.GetKeyDown(KeyCode.Backspace) && GameOverUI.activeSelf == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
