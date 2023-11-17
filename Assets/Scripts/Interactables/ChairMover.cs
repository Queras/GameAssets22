using UnityEngine;

public class ChairMover : Interactable
{
    PlayerController controller;
    private Vector3 ofsett;
    bool hasInteracted;
    [SerializeField] private float distanceFromPlayer = 1;
    [SerializeField] private Transform direction;
    public override void Interact(PlayerController caller)
    {
        hasInteracted = !hasInteracted;
        if (!hasInteracted) return;

        controller = caller;
        ofsett = controller.hit.point - transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Enviroment") { return; }
        hasInteracted = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (controller == null || !hasInteracted) { return; }
        /* if (Input.GetMouseButtonDown(1)) { hasInteracted = false; }*/
        var newPos = controller.hit.point + ofsett;
        var camTrans = controller.gameObject.transform;
        var camRot = Camera.main.transform.rotation.eulerAngles.y;
        direction.rotation = Quaternion.Euler(0, camRot, 0);
        var pizza = (direction.forward * distanceFromPlayer) + camTrans.position;
        pizza.y = 2.66f;
        transform.position = pizza;
    }
}
