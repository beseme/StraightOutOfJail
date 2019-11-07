using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepyGuard : MonoBehaviour
{
    //sleep
    private float _sleepTimer = 1;
    private bool _awake;

    //hitdetection
    private RaycastHit2D _ray;
    private SpriteRenderer _render;
    private Vector2 _rayDir;
    public Move Player;

    //visual
    [SerializeField]
    private Sprite[] _sprites;
    private int _spriteIndex;
    private LineRenderer _view;
    private Vector3 _lineOrigin;
    private Vector3 _lineDirection;
    public float LineLength;
    private Vector3[] _points;
    private ParticleSystem _ZZZ;

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
        _render = GetComponent<SpriteRenderer>();
        if (_render.flipX)
        {
            _rayDir = gameObject.transform.right;
            _lineOrigin = new Vector3(1, 0, 0);
            _lineDirection = new Vector3(LineLength, 0, 0);
        }
        else
        {
            _rayDir = -gameObject.transform.right;
            _lineOrigin = new Vector3(-1, 0, 0);
            _lineDirection = new Vector3(-LineLength, 0, 0);
            }
        _view = GetComponent<LineRenderer>();
        _points = new Vector3[2];
        _spriteIndex = 1;
        _awake = false;
        _source = GetComponent<AudioSource>();
        _playable = true;
        _ZZZ = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        _ray = Physics2D.Raycast(gameObject.transform.position, _rayDir, 10, LayerMask.GetMask("Player"));
        if(_ray && _awake && !Player._hidden && Active.Active)
        {
            Overlay.Fail();
            if (_playable)
            {
                _source.PlayOneShot(_clip, 1);
                _playable = false;
            }
        }

        if (Active.Active)
        {
            _sleepTimer -= Time.deltaTime;
            if (_sleepTimer <= 0)
            {
                _sleepTimer = 1;
                _awake = !_awake;
                _view.enabled = !_view.enabled;
                _spriteIndex += 1;
                if (_awake)
                    _ZZZ.Stop();
                else
                    _ZZZ.Play();

                GetComponent<SpriteRenderer>().sprite = _sprites[_spriteIndex % 2];
            }
        }
        else
        {
            _view.enabled = false;
            _ZZZ.Stop();
        }

        _points[0] = gameObject.transform.position + _lineOrigin;
        _points[1] = gameObject.transform.position + _lineDirection;
        _view.SetPositions(_points);
    }
}
