using UnityEngine;

public class DialogueTriggerBath : DialogueTrigerBox
{
    public override void OnTriggerEnter(Collider other)
    {
        var interactable = other.transform.gameObject.GetComponent<ChairMover>();
        if (interactable) gameObject.SetActive(false);
        base.OnTriggerEnter(other);

    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

    }

}
