using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Elevator")
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 6, 0);
    }

}