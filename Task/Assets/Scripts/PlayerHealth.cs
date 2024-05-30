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
    public GameObject MenuUI;

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

        if (Input.GetKeyDown(KeyCode.Escape) && GameOverUI.activeSelf == true && MenuUI.activeSelf == false)
        {
            SceneManager.LoadScene("Menu");
        }


        if (Input.GetKeyDown(KeyCode.Space) && StartUI.activeSelf == true && MenuUI.activeSelf == false)
        {
            StartUI.SetActive(false);
            GetComponent<PlayerController>().enabled = true;
            GetComponent<CameraController>().enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && GameOverUI.activeSelf == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


        if (StartUI.activeSelf == false && GameOverUI.activeSelf == false && MenuUI.activeSelf == false && Input.GetKey(KeyCode.Tab))
        {
            MenuUI.SetActive(true);
            BackgroundMusic.Pause();
            GetComponent<PlayerController>().enabled = false;
            GetComponent<CameraController>().enabled = false;
        }

        if (Input.GetKey(KeyCode.Escape) && MenuUI.activeSelf == true)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Menu");
        }

        if (Input.GetKey(KeyCode.Space) && MenuUI.activeSelf == true)
        {
            MenuUI.SetActive(false);
            BackgroundMusic.UnPause();
            GetComponent<PlayerController>().enabled = true;
            GetComponent<CameraController>().enabled = true;
        }
    }
}
