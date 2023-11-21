using UnityEngine;

public abstract class Interactable : MonoBehaviour, IInteractable
{
    public abstract void Interact(PlayerController caller);
}

