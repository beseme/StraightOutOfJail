using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMANU : MonoBehaviour
{
    public static bool GameIsPause = false;

    public GameObject _pauseMenuUI;

    public FollowCam Active;

    public AudioSource GlobalVolume;
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button9))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        _pauseMenuUI.SetActive(false);
        Active.Active = true;
        GlobalVolume.volume = 1f;
        GameIsPause = false;
    }
    void Pause()
    {
        _pauseMenuUI.SetActive(true);
        Active.Active = false;
        GlobalVolume.volume = .1f;
        GameIsPause = true;
    }

    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
