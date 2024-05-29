using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeimMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Puzzle 1");
    }

    public void ExitGame()
    {
        Debug.Log("Игра Закрыта");
        Application.Quit();
    }

}
