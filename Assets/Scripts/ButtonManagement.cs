using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagement : MonoBehaviour
{
    public GUI Paused;

    public void Pause()
    {
        Paused.Resume();
    }

    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayHard()
    {
        SceneManager.LoadScene(2);
    }
}
