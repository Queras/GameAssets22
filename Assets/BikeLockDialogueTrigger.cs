using UnityEngine;

public class BikeLockDialogueTrigger : DialogueTrigerBox
{
    public GameObject redLense, greenLense;
    public override void OnTriggerEnter(Collider other)
    {

        base.OnTriggerEnter(other);

    }


    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
    }

    void Update()
    {
        if (!redLense.activeSelf && !greenLense.activeSelf)

            gameObject.SetActive(false);
    }






}



