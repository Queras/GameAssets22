using UnityEngine;

public class KeyScript : Interactable
{
    public DoorControl DoorControl;
    public GameObject Red, Green, Blue, Pink;
    [SerializeField] private KeyType keyType;
    public enum KeyType
    {
        Red, Green, Blue, Pink
    }
    void Start()
    {

    }
    private void OnValidate()
    {

        foreach (Transform t in transform) { t.gameObject.SetActive(false); }

        switch (keyType)
        {
            case KeyType.Red:
                Red.SetActive(true);
                break;
            case KeyType.Green:
                Green.SetActive(true);
                break;
            case KeyType.Blue:
                Blue.SetActive(true);
                break;
            case KeyType.Pink:
                Pink.SetActive(true);
                break;
            default: Debug.Log(""); break;
        }


    }
    // Update is called once per frame
    void Update()
    {

    }

    public override void Interact(PlayerController caller)
    {
        DoorControl.haskey = true; gameObject.SetActive(false);
    }
}
