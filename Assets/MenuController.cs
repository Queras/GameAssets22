using System.Collections;
using UnityEditor;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject resume;
    // Start is called before the first frame update

    public void ExitGame()
    {
        StartCoroutine(TriggerExitGameDelayed());
    }

    private static IEnumerator TriggerExitGameDelayed()
    {
        Debug.Log("EXIT GAME");
        yield return new WaitForSecondsRealtime(1);
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
