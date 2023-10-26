using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float turnSpeed = 200.0f;
    public float jumpSpeed = 10.0f;
    private Rigidbody m_rigidbody;
    private float turn;
    private float move;
    private bool jump;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * 1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        turn = Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed;
        move = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        jump = Input.GetKeyDown(KeyCode.Space);
    }
    // Update is called once per frame
    void FixedUpdate()
    {   
        
        transform.Rotate(0.0f, turn, 0.0f);
        transform.position = transform.position + transform.forward * move;
        if (!(m_rigidbody.velocity.y == 0)) return;
        if (jump) m_rigidbody.velocity += Vector3.up * jumpSpeed;





    }
}
