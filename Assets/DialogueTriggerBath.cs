using UnityEngine;

public class DialogueTriggerBath : DialogueTrigerBox
{
    public override void OnTriggerEnter(Collider other)
    {
        var interactable = other.transform.gameObject.GetComponent<ChairMover>();
        if (interactable) gameObject.SetActive(false);
        base.OnTriggerEnter(other);
        SetJumpState(false, other);
    }
    private void SetJumpState(bool jump, Collider other)
    {

        if (other.tag != "Player") { return; }
        var isplayer = other.transform.gameObject.TryGetComponent<PlayerController>(out var player1);
        if (isplayer) player1.canJump = jump;
    }
    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        SetJumpState(true, other);

    }

}
