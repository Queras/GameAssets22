using UnityEngine;

public class VMExit : MonoBehaviour

{
    public GameObject dialougePrefab, dialogueText, getGlases, VMMesh;
    private void OnTriggerExit(Collider other)
    {
        if (getGlases.activeSelf) return;
        if (other.tag != "Player") { return; }
        dialogueText.SetActive(false);
        dialougePrefab.SetActive(false);
        if (VMMesh.activeSelf) return;
        gameObject.SetActive(false);
        transform.parent.gameObject.SetActive(false);
    }
}
