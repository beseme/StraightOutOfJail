using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _sprite = new Sprite[2];
    private int _spriteIndex = 0;
    private bool _flipped;
    private float _stamina;
    public UIBar _bar;

    // Start is called before the first frame update
    void Start()
    {
        _flipped = false;
        _stamina = 100;
    }

    // Update is called once per frame
    void Update()
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
            if(_flipped)
                gameObject.transform.position += new Vector3(-2, 0, 0);
            else
                gameObject.transform.position += new Vector3(2, 0, 0);
            _stamina -= 5;
        }

        _bar.GetComponent<UIBar>().Bar(_stamina, 1, 100, 0, 1);
    }
}
