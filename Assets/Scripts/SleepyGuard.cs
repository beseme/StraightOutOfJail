using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepyGuard : MonoBehaviour
{
    private float _sleepTimer = 1;
    private RaycastHit2D _ray;
    [SerializeField]
    private Sprite[] _sprites;
    private Vector2 _rayDir;
    private bool _awake;
    public Image Fail;
    private int _spriteIndex = 0;

    private LineRenderer _view;
    private Vector3 _lineOrigin;
    private Vector3 _lineDirection;
    public float LineLength;
    private Vector3[] _points;

    // Start is called before the first frame update
    void Start()
    {
        _sprites = new Sprite[2];
        if (gameObject.transform.localScale == new Vector3(-1, 1, 1))
            _rayDir = gameObject.transform.right;
        else
            _rayDir = -gameObject.transform.right;
        _view = GetComponent<LineRenderer>();
        _points = new Vector3[2];
        _lineDirection = new Vector3(-LineLength, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_sleepTimer);

        _ray = Physics2D.Raycast(gameObject.transform.position, _rayDir, 10, LayerMask.GetMask("Player"));
        if(_ray && _awake)
        {
            Fail.gameObject.SetActive(true);
        }

        _sleepTimer -= Time.deltaTime;
        if(_sleepTimer <= 0)
        {
            _sleepTimer = 1;
            _awake = !_awake;
            _view.enabled = !_view.enabled;
            _spriteIndex += 1;
            if (_spriteIndex > 1)
                _spriteIndex = 0;
            GetComponent<SpriteRenderer>().sprite = _sprites[_spriteIndex];
        }

        _lineOrigin = gameObject.transform.position;
        _points[0] = _lineOrigin;
        _points[1] = _lineOrigin + _lineDirection;
        _view.SetPositions(_points);
    }
}
