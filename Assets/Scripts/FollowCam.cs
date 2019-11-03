using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform _player;
    private float _smoothen;
    private Vector3 _offset;
    public bool Active;
    public AudioClip _startSound;
    private float _startSequence;
    private float _zoomIn = 3;

    // Start is called before the first frame update
    void Start()
    {
        Active = false;
        _startSequence = _startSound.length;
        transform.position = _player.transform.position;
        _smoothen = .02f;
        gameObject.transform.position = new Vector3(0, 0, -200);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _startSequence -= Time.deltaTime;
        _zoomIn -= Time.deltaTime;
        if(_startSequence <= 0)
            _smoothen = .04f;
        if(_zoomIn <= 0 && _zoomIn > -1)
            Active = true;

        Vector3 targetPosition = _player.position + new Vector3(0, 1.5f, -15) + _offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, _smoothen);
        transform.position = smoothPosition;
    }
}
