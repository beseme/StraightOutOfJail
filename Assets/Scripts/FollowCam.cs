using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform _player;
    //private Transform _follow;

    private float _smoothen;
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = _player.transform.position;
        _smoothen = .03f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPosition = _player.position + new Vector3(0, 1.5f, -10) + _offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, _smoothen);
        transform.position = smoothPosition;
    }
}
