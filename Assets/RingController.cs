using UnityEngine;

public class RingController : Interactable
{

    private bool ringTrigger;
    [SerializeField] private GameObject ring;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ringTrigger) return;

    }
    public override void Interact(PlayerController caller)
    {
        ringTrigger = true;
        if (ringTrigger == true)
        {

            ring.transform.Rotate(60.0f, 0.0f, 0.0f, Space.Self);

        }

    }
}
