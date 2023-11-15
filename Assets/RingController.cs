using UnityEngine;

public class RingController : Interactable
{

    private bool ringTrigger;
    [SerializeField] private int lerpSpeed;
    private float lerpAlpha;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!ringTrigger) return;
        lerpAlpha += lerpSpeed;
        transform.Rotate(lerpSpeed, 0, 0, Space.Self);

        if (lerpAlpha == 60)
        {
            ringTrigger = false;
            lerpAlpha = 0;
        }
    }
    public override void Interact(PlayerController caller)
    {
        if (ringTrigger) return;
        ringTrigger = true;


    }
}
