using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float turnSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float turn = Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed;
        float move = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Rotate(0.0f, turn, 0.0f);
        transform.position = transform.position + transform.forward * move;
        
    }
}
