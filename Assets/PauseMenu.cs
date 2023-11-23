using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;
    public CharacterController characterController;
    public PlayerController playerController;
    private bool isPaused;
    public void OpenPauseMenu()
    {
        isPaused = !isPaused;
        menu.SetActive(isPaused);
        characterController.enabled = !isPaused;
        playerController.enabled = !isPaused;
        Time.timeScale = isPaused ? 0.0f : 1.0f;
        ToggleCursorLockMode(!isPaused);
    }

    public void ToggleCursorLockMode(bool enable)
    {
        if (enable)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { OpenPauseMenu(); }
    }
}
