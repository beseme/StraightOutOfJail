using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guard : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Vector3 _move = new Vector3(-.1f,0,0);
    private RaycastHit2D _hit;
    private RaycastHit2D _wallHit;
    private Transform _rayOrigin;
    private Vector2 _rayDirection;
    private Vector3 _lineOrigin;
    private Vector3 _lineDirection;
    public float LineLength;
    private Vector3[] _points;
    [SerializeField]
    private Sprite[] _spriteFlip = new Sprite[2];
    private int _spriteIndex = 0;
    private LineRenderer _view;
    [SerializeField]
    private Image _fail;
    public Move Player;
    public FollowCam Active;

    private AudioSource _source;
    public AudioClip _clip;
    private bool _playable;

    // Start is called before the first frame update
    void Start()
    {
        _rayDirection = Vector2.left;
        _rayOrigin = gameObject.transform;
        _view = GetComponent<LineRenderer>();
        _points = new Vector3[2];
        _lineDirection = new Vector3(-LineLength, 0, 0);
        _lineOrigin = new Vector3(-1, 0, 0);
        _fail.gameObject.SetActive(false);
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
        if (Active.Active)
        {
            gameObject.transform.position += _move * _speed;
            _view.enabled = true;
        }

        _points[0] = gameObject.transform.position +_lineOrigin;
        _points[1] = gameObject.transform.position + _lineDirection;

        _view.SetPositions(_points);

        _hit = Physics2D.Raycast(_rayOrigin.position, _rayDirection, 5f, LayerMask.GetMask("Player"));
        _wallHit = Physics2D.Raycast(_rayOrigin.position, _rayDirection, 4f, LayerMask.GetMask("Wall"));

        if (_hit && !Player._hidden && Active.Active)
        {
            _fail.gameObject.SetActive(true);
            Active.Active = false;
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
}
