using System;
using UnityEngine;

public class DialogueNeedVM : DialogueTrigerBox
{
    public GameObject ViewMaster, nextNote, getGlases;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        if (ViewMaster == null) throw new Exception("VM Not Sett");

    }
    public override void OnTriggerEnter(Collider other)
    {
        if (!nextNote.activeSelf) return;
        base.OnTriggerEnter(other);
    }
    public override void OnTriggerExit(Collider other)
    {
        if (getGlases.activeSelf) return;
        base.OnTriggerExit(other);
    }
    // Update is called once per frame
    void Update()
    {
        if (ViewMaster.activeSelf) return;

        gameObject.SetActive(false);
    }
}
