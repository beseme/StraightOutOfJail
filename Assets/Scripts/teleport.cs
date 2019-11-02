using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    private AudioSource _sound;
    public AudioClip _clip;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Elevator")
        {

            StartCoroutine(Emu());

        }
    }

    private IEnumerator Emu()
    {
        _sound.PlayOneShot(_clip, 1);
        yield return new WaitForSeconds(_clip.length * 0.5f);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 6, 0);
    }

}