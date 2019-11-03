using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalDoor : MonoBehaviour
{
    public Image Win;
    public FollowCam Active;
    private AudioSource _source;
    public AudioClip Clip;
    private bool _played;
    private RaycastHit2D _hit;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
        _played = false;
    }


    private IEnumerator Finish()
    {
        if(!_played)
        _source.PlayOneShot(Clip, 1);
        _played = true;
        yield return new WaitForSeconds(.1f);
        Win.gameObject.SetActive(true);
    }

    private void Update()
    {
        _hit = Physics2D.Raycast(gameObject.transform.position, -Vector3.forward, 5, LayerMask.GetMask("Player"));
        if (Active.Active)
        {
            if (_hit)
            {
                Active.Active = false;
                StartCoroutine(Finish());
            }
        }

    }
}
