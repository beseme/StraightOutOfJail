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
    private int _spriteIndex;
    public Move Player;

    private LineRenderer _view;
    private Vector3 _lineOrigin;
    private Vector3 _lineDirection;
    public float LineLength;
    private Vector3[] _points;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.transform.localScale == new Vector3(-1, 1, 1))
            _rayDir = gameObject.transform.right;
        else
            _rayDir = -gameObject.transform.right;
        _view = GetComponent<LineRenderer>();
        _points = new Vector3[2];
        _lineDirection = new Vector3(-LineLength, 0, 0);
        _spriteIndex = 1;
        _awake = true;
    }

    // Update is called once per frame
    void Update()
    {
        _ray = Physics2D.Raycast(gameObject.transform.position, _rayDir, 10, LayerMask.GetMask("Player"));
        if(_ray && _awake && !Player._hidden)
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

            GetComponent<SpriteRenderer>().sprite = _sprites[_spriteIndex % 2];
        }

        _lineOrigin = gameObject.transform.position;
        _points[0] = _lineOrigin;
        _points[1] = _lineOrigin + _lineDirection;
        _view.SetPositions(_points);
    }
}
