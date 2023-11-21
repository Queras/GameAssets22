using UnityEngine;

public class StartDialogue : Dialogue
{
    // Start is called before the first frame update
    public GameObject nextText;
    public override void Start()
    {
        base.Start();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") { return; }
        DialogueText.SetActive(false);
        nextText.SetActive(true);
        // todo read the note

    }
}
