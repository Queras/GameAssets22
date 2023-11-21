using UnityEngine;

public class VMExit : MonoBehaviour

{
    public GameObject dialougePrefab, dialogueText, getGlases;
    private void OnTriggerExit(Collider other)
    {
        if (getGlases.activeSelf) return;
        if (other.tag != "Player") { return; }
        dialogueText.SetActive(false);
        dialougePrefab.SetActive(false);
        gameObject.SetActive(false);
        transform.parent.gameObject.SetActive(false);
    }
}
