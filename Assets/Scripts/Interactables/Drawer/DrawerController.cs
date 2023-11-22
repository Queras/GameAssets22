using System;
using UnityEngine;
[Serializable]
public class KeyManager
{
    [SerializeField] public bool hasRedKey, hasGreenKey, hasBlueKey, hasPinkKey;
}

public class DrawerController : Interactable
{
    [SerializeField] private KeyManager keyManager = new KeyManager();
    private float lerpAlpha;
    private bool drawertrigger;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private GameObject drawer, redKey, greenKey, blueKey, pinkKey;
    [SerializeField] private Transform startPos, stopPos;
    [SerializeField] private BoxCollider mCollider;
    [SerializeField] private AudioClip mClip;
    // Start is called before the first frame update
    void Start()
    {
        mCollider.enabled = false;

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(startPos.position, 0.5f);
        Gizmos.DrawWireSphere(stopPos.position, 0.5f);
    }
    private void OnValidate()
    {
        if (redKey) redKey.SetActive(keyManager.hasRedKey);

        if (greenKey) greenKey.SetActive(keyManager.hasGreenKey);

        if (blueKey) blueKey.SetActive(keyManager.hasBlueKey);

        if (pinkKey) pinkKey.SetActive(keyManager.hasPinkKey);

    }
    // Update is called once per frame
    void Update()
    {


        if (!drawertrigger)
            return;
        if (lerpAlpha < 1) lerpAlpha += Time.deltaTime * lerpSpeed;
        drawer.transform.position = Vector3.Lerp(startPos.position, stopPos.position, lerpAlpha);
        if (lerpAlpha >= 1)
        {
            mCollider.enabled = !mCollider.enabled;
            drawertrigger = false;
            lerpAlpha = 0;
            var temppos = stopPos;
            stopPos = startPos;
            startPos = temppos;
        }


    }
    public override void Interact(PlayerController caller)
    {
        drawertrigger = true;
        Debug.Log("Success");

    }

}