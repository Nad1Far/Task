using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public AudioSource BackgroundMusic;
    public AudioSource DeathSound;
    public GameObject StartUI;
    public GameObject GameOverUI;

    public bool PlayerIsDead = false;


    private void Start()
    {
        StartUI.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<CameraController>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet" || other.gameObject.tag == "Laser" || other.gameObject.tag == "Shape")
        {
            GameOverUI.SetActive(true);
            GetComponent<PlayerController>().enabled = false;
            GetComponent<CameraController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            PlayerIsDead = true;
            BackgroundMusic.Stop();
            DeathSound.Play();
        }
    }

    private void Update()
    {
        if (PlayerIsDead == true)
        {
            GetComponent<CapsuleCollider>().isTrigger = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && GameOverUI.activeSelf == true)
        {
            SceneManager.LoadScene("Menu");
        }


        if (Input.GetKeyDown(KeyCode.Space) && StartUI.activeSelf == true)
        {
            StartUI.SetActive(false);
            GetComponent<PlayerController>().enabled = true;
            GetComponent<CameraController>().enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && GameOverUI.activeSelf == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
