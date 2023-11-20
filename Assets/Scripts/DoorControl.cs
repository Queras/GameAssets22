


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{

    public Animator door = null;
    public bool haskey = false;
    public bool isDoorOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        door = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isDoorOpen == false)
        {
            if (door && haskey)
            {

                Debug.Log("Door Open");
                door.SetTrigger("openDoor");
                isDoorOpen = true;
            }
            else if (door == null)
            {
                Debug.Log("No door");
            }

        }


     
    }
}
