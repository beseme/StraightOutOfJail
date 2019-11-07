using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUI : MonoBehaviour
{
    public bool GameIsPause;

    public Image _pauseMenuUI;
    public Image FailScreen;
    public Image WinScreen;

    public FollowCam Active;

    public AudioSource GlobalVolume;


    private void Start()
    {
        _pauseMenuUI.gameObject.SetActive(false);
        FailScreen.gameObject.SetActive(false);
        WinScreen.gameObject.SetActive(false);
        GameIsPause = false;
    }

    public void Fail()
    {
        FailScreen.gameObject.SetActive(true);
        Active.Active = false;
        GlobalVolume.volume = .1f;
    }

    public void Win()
    {
        WinScreen.gameObject.SetActive(true);
        Active.Active = false;
        GlobalVolume.volume = .1f;
    }

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
        _pauseMenuUI.gameObject.SetActive(false);
        Active.Active = true;
        GlobalVolume.volume = 1f;
        GameIsPause = false;
    }
    void Pause()
    {
        _pauseMenuUI.gameObject.SetActive(true);
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
