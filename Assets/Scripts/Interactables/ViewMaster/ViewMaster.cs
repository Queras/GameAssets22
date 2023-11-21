using UnityEngine;

public class ViewMaster : Interactable
{
    public GameObject vmMesh, dialougePrefab, dialogueText, getGlases;


    public override void Interact(PlayerController caller)
    {
        if (getGlases.activeSelf) return;
        caller.viewMaster = true;
        vmMesh.SetActive(false);
        dialougePrefab.SetActive(true);
        dialogueText.SetActive(true);
    }




}

