public class LensScript : Interactable
{

    private bool hasAdded;
    public LensColor color;
    // Start is called before the first frame update
    public override void Interact(PlayerController caller)
    {
        if (hasAdded) return;
        hasAdded = true;
        caller.AddToLenseInventory(color);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
