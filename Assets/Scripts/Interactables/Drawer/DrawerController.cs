using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DrawerController : MonoBehaviour
{
    [Serializable] private class KeyManager
    {
      [SerializeField] public bool hasRedKey, hasGreenKey, hasBlueKey, hasPinkKey;  
    }
    private float lerpAlpha;
    private bool isDrawerOpen = false;
    private bool drawertrigger;
    [SerializeField]private float lerpSpeed;
    [SerializeField] private GameObject drawer, redKey, greenKey, blueKey, pinkKey;
    [SerializeField] private Transform startPos, stopPos;
    [SerializeField] private KeyManager keyManager = new KeyManager();
    // Start is called before the first frame update
    void Start()
    {
       
        
    }
    private void OnValidate()
    {
        redKey.SetActive(keyManager.hasRedKey);
       
        greenKey.SetActive(keyManager.hasGreenKey);
      
        blueKey.SetActive(keyManager.hasBlueKey);
        
        pinkKey.SetActive(keyManager.hasPinkKey);
        
    }
    // Update is called once per frame
    void Update()
    {
        
            
        if (!drawertrigger)
            return;
        if (lerpAlpha < 1) lerpAlpha += Time.deltaTime * lerpSpeed;
        if (lerpAlpha >= 1)
        {
            drawertrigger = false; 
            lerpAlpha = 0;
            var temppos = stopPos;
            stopPos = startPos;
            startPos = temppos;
        }
        drawer.transform.position = Vector3.Lerp(startPos.position, stopPos.position, lerpAlpha);

    }
    public void Interact()
    {
    drawertrigger = true;
        Debug.Log("Success");

    }
    
}
