using UnityEngine;

public class DialogueTrigerBox : Dialogue
{
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") { return; }
        SettDialogueEnabled(true);
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player") { return; }
        SettDialogueEnabled(false);
    }
}


