using UnityEngine;

public class ViewMaster : Interactable
{



    public override void Interact(PlayerController caller)
    {
        caller.viewMaster = true;
        gameObject.SetActive(false);
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
public abstract class Interactable : MonoBehaviour, IInteractable
{
    public abstract void Interact(PlayerController caller);
}

public interface IInteractable

{
    void Interact(PlayerController caller);


}
