using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    [SerializeField]
    public GameObject _player;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _player.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y - 6, 0);
    }
    // Update is called once per frame



}