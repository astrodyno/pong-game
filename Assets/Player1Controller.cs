using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    Vector3 initialPosition;
    Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
        initialPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();

    }

    public void resetPos() 
    {
        transform.position = initialPosition;
        rigidbody.velocity = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.up * Time.deltaTime * 4f, Space.World);
        }
        else if (Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector3.down * Time.deltaTime * 4f, Space.World);
        }
        
    }
}
