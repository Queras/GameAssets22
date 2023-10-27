using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseDrawer : MonoBehaviour
{
    public Animation Drawer1;
    public bool opened = false;
    private float time = 0.0f;


    // Update is called once per frame
    void Update()
    {
        //press right mouse (e for now)
        if (Input.GetKeyDown(KeyCode.E))
        {
        //Drawer open
         Drawer1.Play();

         opened = true;

        }
        if (opened)
        {
            time = Time.deltaTime;  
        }
        



        
        //grab key

        //press right mouse

        //close drawer
    }
}
