using UnityEngine;

public class CodeKeeper : MonoBehaviour
{

    public GameObject Ring1, Ring2, Ring3, Lock;
    private bool SetActive;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void GetComponent(Quaternion rotation)
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent(Ring1.transform.rotation);
        GetComponent(Ring2.transform.rotation);
        GetComponent(Ring3.transform.rotation);



        SetActive = true;

        if (Ring1.GetComponent<Transform>().rotation.x >= 60)
            if (Ring2.GetComponent<Transform>().rotation.x >= 60)
                if (Ring3.GetComponent<Transform>().rotation.x >= 60)
                {
                    SetActive = false;
                }





    }
}
