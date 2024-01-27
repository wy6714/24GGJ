using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beats : MonoBehaviour
{
    public Sprite touchedSprite;
    public Sprite originalSprite;
    public int stage = 0;
    public bool hasget = false;
    public int score = 1;

    public static event Action<GameObject> getBeats;//music manager

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(hasget == false)
        {
            GetComponent<SpriteRenderer>().sprite = originalSprite;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && stage == 1)
        {

            GetComponent<SpriteRenderer>().sprite = touchedSprite;
            getBeats?.Invoke(gameObject);//play audio, add score
        }

        if(collision.CompareTag("Shadow") && stage == 1)
        {
            GetComponent<SpriteRenderer>().sprite = touchedSprite;
            getBeats?.Invoke(gameObject);//play audio, add score
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
