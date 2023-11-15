using UnityEngine;

public class CodeKeeper : MonoBehaviour
{

    public GameObject ring1, ring2, ring3;
    private Transform mRing1, mRing2, mRing3;

    // Start is called before the first frame update
    void Start()
    {
        mRing1 = ring1.GetComponent<Transform>();
        mRing2 = ring2.GetComponent<Transform>();
        mRing3 = ring3.GetComponent<Transform>();

    }


    // Update is called once per frame
    void Update()
    {
        mRing1.localRotation.ToAngleAxis(out var r1, out var axis1);
        mRing2.localRotation.ToAngleAxis(out var r2, out var axis2);
        mRing3.localRotation.ToAngleAxis(out var r3, out var axis3);

        Debug.Log("1" + r1);
        if (r1 - 180 <= 5) return;

        if (r2 != 60) return;
        Debug.Log("2");
        if (r3 != 240) return;
        Debug.Log("3");
        gameObject.SetActive(false);






    }
}
