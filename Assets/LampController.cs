using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : Interactable
{
    public Light mLight;
    public override void Interact(PlayerController caller)
    {
        mLight.enabled = !mLight.enabled;
    }

   
}
