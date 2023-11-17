using Unity.VisualScripting;
using UnityEngine;

public class RingController : Interactable
{

    private bool ringTrigger;
    [SerializeField] private int lerpSpeed, clicksNeeded;
    private float lerpAlpha;
    private int clicksDone;
    [DoNotSerialize] public bool solved;
    // Start is called before the first frame update
    void Start()
    {
        if (clicksNeeded == 0) Debug.LogWarning("check if clicks needed is correct");
    }

    // Update is called once per frame
    void Update()
    {
        if (!ringTrigger) return;
        lerpAlpha += lerpSpeed;
        transform.Rotate(lerpSpeed, 0, 0, Space.Self);

        if (lerpAlpha == 60)
        {
            clicksDone++;
            if (clicksDone == clicksNeeded) solved = true; else solved = false;
            ringTrigger = false;
            lerpAlpha = 0;
        }
    }
    public override void Interact(PlayerController caller)
    {
        if (ringTrigger) return;
        ringTrigger = true;
        if (clicksDone == 6) { clicksDone = 0; }



    }
}
