using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet" || other.gameObject.tag == "Laser")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
