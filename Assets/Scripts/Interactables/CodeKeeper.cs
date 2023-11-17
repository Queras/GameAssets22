using UnityEngine;

public class CodeKeeper : MonoBehaviour
{

    public GameObject ring1, ring2, ring3;
    private RingController mRing1, mRing2, mRing3;

    // Start is called before the first frame update
    void Start()
    {
        mRing1 = ring1.GetComponent<RingController>();
        mRing2 = ring2.GetComponent<RingController>();
        mRing3 = ring3.GetComponent<RingController>();

    }


    // Update is called once per frame
    void Update()
    {
        if (!mRing1.solved) return;
        if (!mRing2.solved) return;
        if (!mRing3.solved) return;


        gameObject.SetActive(false);

    }
}
