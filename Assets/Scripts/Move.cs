using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))        
            gameObject.transform.position += new Vector3(-2, 0, 0);
        if (Input.GetKeyDown(KeyCode.D))
            gameObject.transform.position += new Vector3(2, 0, 0);

    }
}
