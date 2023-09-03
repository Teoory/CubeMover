using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watchToGift : MonoBehaviour
{
    public GameObject giftObject;
    public float activationTime = 60f; // 1 dakika
    [SerializeField]private float elapsedTime = 0f;
    private bool objectIsActive = true;


    // private void Awake()
    // {
    //     DontDestroyOnLoad(this.gameObject);
    // }
    
    private void Update()
    {
        giftObject = GameObject.FindGameObjectWithTag("WatchToGift");
        if (!objectIsActive)
        {
            elapsedTime += Time.deltaTime;
            giftObject.SetActive(false);

            if (elapsedTime >= activationTime)
            {
                giftObject.SetActive(true);
                objectIsActive = true;
                elapsedTime = 0f;
            }
        }
    }

    public void objectDeactive()
    {
        objectIsActive = false;
    }
}
