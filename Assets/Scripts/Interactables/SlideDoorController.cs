using UnityEngine;

public class SlideDoorController : Interactable

{
    private float lerpAlpha;
    [SerializeField] private GameObject m_Lock;
    private bool slideDoor;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private Vector3 startPos, stopPos;
    [SerializeField] private BoxCollider mCollider;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        mCollider.enabled = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(startPos, Vector3.one * 0.1f);
        Gizmos.DrawCube(stopPos, Vector3.one * 0.1f);
    }
    void Update()
    {
        if (!slideDoor) { return; }
        lerpAlpha += Time.deltaTime * lerpSpeed;
        transform.position = Vector3.Lerp(startPos, stopPos, lerpAlpha);
        if (lerpAlpha >= 1)
        {
            mCollider.enabled = !mCollider.enabled;
            slideDoor = false;
            lerpAlpha = 0;
            var temppos = startPos;
            startPos = stopPos;
            stopPos = temppos;
        }




    }

    public override void Interact(PlayerController caller)
    {
        if (m_Lock == null || m_Lock.activeInHierarchy) return;
        slideDoor = true;
        lerpAlpha = 0;
    }
}
