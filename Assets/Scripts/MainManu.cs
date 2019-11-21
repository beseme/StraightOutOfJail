using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour
{
    private AudioSource _buttonSource;
    [SerializeField]
    private AudioClip _onClickClip;

    private void Start()
    {
        _buttonSource = GetComponent<AudioSource>();
    }

    private IEnumerator Click()
    {
        _buttonSource.PlayOneShot(_onClickClip, 3);
        yield return new WaitForSeconds(_onClickClip.length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayGame()
    {
        StartCoroutine(Click());
    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
