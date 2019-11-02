using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        _rayDirection = Vector2.left;
        _rayOrigin = gameObject.transform;
        _view = GetComponent<LineRenderer>();
        _points = new Vector3[2];
        _lineDirection = new Vector3(-LineLength, 0, 0);
    }

    void Flip()
    {
        _lineDirection = -_lineDirection;
        _rayDirection = -_rayDirection;
        _speed *= -1f;
        _spriteIndex += 1;
        if (_spriteIndex > 1)
            _spriteIndex = 0;
        GetComponent<SpriteRenderer>().sprite = _spriteFlip[_spriteIndex];
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += _move * _speed;

        _lineOrigin = gameObject.transform.position;

        _points[0] = _lineOrigin;
        _points[1] = _lineOrigin + _lineDirection;

        _view.SetPositions(_points);

        _hit = Physics2D.Raycast(_rayOrigin.position, _rayDirection, 5f, LayerMask.GetMask("Player"));
        _wallHit = Physics2D.Raycast(_rayOrigin.position, _rayDirection, 4f, LayerMask.GetMask("Wall"));

        if (_wallHit)
            Flip();

    }
}
