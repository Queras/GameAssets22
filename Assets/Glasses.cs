using UnityEngine;

public class Glasses : Interactable
{
    public GameObject glasses, blackAndWhite, dialoguebox, finaleText, start;
    public override void Interact(PlayerController caller)
    {
        glasses.SetActive(false);
        blackAndWhite.SetActive(false);
        dialoguebox.SetActive(true);
        finaleText.SetActive(true);
        start.SetActive(false);
    }


}
