using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    private DrawerController controller;
    public DrawerController GetController() { return controller; }  
    void Start()
    {
        controller= GetComponentInParent<DrawerController>();
    }


    
}
