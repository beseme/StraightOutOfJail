using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Move : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _sprite = new Sprite[2];
    private int _spriteIndex = 0;
    private bool _flipped;
    private bool _jumpPossible;
    public bool _hidden;
    private float _stamina;
    public UIBar _bar;
    private RaycastHit2D _rayBlack;
    private RaycastHit2D _rayWhite;
    public PostProcessVolume Vignette;
    


    // Start is called before the first frame update
    void Start()
    {
        _flipped = false;
        _stamina = 100;
        _jumpPossible = true;
    }

    // Update is called once per frame
    void Update()
    {
        // movement
        if (_jumpPossible)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _flipped = !_flipped;
                if (_flipped)
                    GetComponent<SpriteRenderer>().sprite = _sprite[1];
                if (!_flipped)
                    GetComponent<SpriteRenderer>().sprite = _sprite[0];
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_flipped)
                    gameObject.transform.position += new Vector3(-2, 0, 0);
                else
                    gameObject.transform.position += new Vector3(2, 0, 0);
                _stamina -= 10;
            }
        }

        // stamina
        if (_stamina < 0)
            _jumpPossible = false;
        if (_stamina > 25)
            _jumpPossible = true;

        _bar.GetComponent<UIBar>().Bar(_stamina, 1, 100, 0, 1);

        if (_stamina <= 100)
            _stamina += Time.deltaTime * 10;


        //hiding
        _rayBlack = Physics2D.Raycast(gameObject.transform.position, gameObject.transform.forward, 10f, LayerMask.GetMask("Black"));
        _rayWhite = Physics2D.Raycast(gameObject.transform.position, gameObject.transform.forward, 10f, LayerMask.GetMask("White"));

        if (_rayBlack && _flipped)
            _hidden = true;
        else if (_rayWhite && !_flipped)
            _hidden = true;
        else
            _hidden = false;

        if (_hidden)
            Vignette.enabled = true;
        else
            Vignette.enabled = false;

    }
}
