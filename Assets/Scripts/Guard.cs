using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guard : MonoBehaviour
{
    //move
    [SerializeField]
    private float _speed;
    private Vector3 _move = new Vector3(-.1f,0,0);
    private RaycastHit2D _wallHit;

    //hitdetection
    private RaycastHit2D _hit;
    private Transform _rayOrigin;
    private Vector2 _rayDirection;
    public Move Player;

    //visual
    private Vector3 _lineOrigin;
    private Vector3 _lineDirection;
    public float LineLength;
    private Vector3[] _points;
    private LineRenderer _view;
   
    public FollowCam Active;

    //audio
    public AudioSource GlobalVolume;
    private AudioSource _source;
    public AudioClip _clip;
    private bool _playable;

    public GUI Overlay;

    // Start is called before the first frame update
    void Start()
    {
        _rayDirection = Vector2.left;
        _rayOrigin = gameObject.transform;
        _view = GetComponent<LineRenderer>();
        _points = new Vector3[2];
        _lineDirection = new Vector3(-LineLength, 0, 0);
        _lineOrigin = new Vector3(-1, 0, 0);
        _source = GetComponent<AudioSource>();
        _playable = true;
    }

    void Flip()
    {
        gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, 1,1);
        _lineDirection = -_lineDirection;
        _lineOrigin = -_lineOrigin;
        _rayDirection = -_rayDirection;
        _speed *= -1f;
    }

    // Update is called once per frame
    void Update()
    {
        _points[0] = gameObject.transform.position +_lineOrigin;
        _points[1] = gameObject.transform.position + _lineDirection;

        _view.SetPositions(_points);

        _hit = Physics2D.Raycast(_rayOrigin.position, _rayDirection, 5f, LayerMask.GetMask("Player"));
        _wallHit = Physics2D.Raycast(_rayOrigin.position, _rayDirection, 4f, LayerMask.GetMask("Wall"));

        if (_hit && !Player._hidden && Active.Active)
        {
            Overlay.Fail();
            if (_playable)
            {
                _source.PlayOneShot(_clip, 1);
                _playable = false;
            }
        }

        if (!Active.Active)
            _view.enabled = false;

        if (_wallHit)
            Flip();
}
    private void FixedUpdate()
    {
        if (Active.Active)
        {
            gameObject.transform.position += _move * _speed;
            _view.enabled = true;
        }
    }
}
