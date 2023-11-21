using System;
using UnityEngine;


public class Dialogue : MonoBehaviour
{
    public GameObject DialoguePrefab;
    public GameObject DialogueText;
    public virtual void SettDialogueEnabled(bool enable)
    {
        DialoguePrefab.SetActive(enable);
        DialogueText.SetActive(enable);
    }

    // Start is called before the first frame update
    public virtual void Start()
    {
        if (!DialoguePrefab || !DialogueText) throw new Exception("Prefab or text not sett");
    }

    // Update is called once per frame 
    void Update()
    {

    }
}
