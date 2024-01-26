using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beats : MonoBehaviour
{
    public Sprite newSprite;
    public int stage = 0;
    public bool hasget = false;

    public static event Action<GameObject> getBeats;//music manager

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && stage == 1)
        {

            GetComponent<SpriteRenderer>().sprite = newSprite;
            getBeats?.Invoke(gameObject);//play audio
        }

        if (collision.CompareTag("Timeline"))
        {
            stage = 1;
            //Debug.Log(stage);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Timeline"))
        {
            stage = 0;
            //Debug.Log(stage);
        }
    }




}
