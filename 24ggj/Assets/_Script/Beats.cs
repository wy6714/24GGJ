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
    private GameObject playerObj;
    public GameObject shadowObj;
    public SpriteRenderer beatsVisual;

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
            //GetComponent<SpriteRenderer>().sprite = originalSprite;
            beatsVisual.sprite = originalSprite;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && stage == 1)
        {
            beatsVisual.sprite = touchedSprite;
            //GetComponent<SpriteRenderer>().sprite = touchedSprite;
            getBeats?.Invoke(gameObject);//play audio, add score
        }

        if (collision.CompareTag("Shadow") && stage == 1)
        {
            //GetComponent<SpriteRenderer>().sprite = touchedSprite;
            beatsVisual.sprite = touchedSprite;
            getBeats?.Invoke(gameObject);//play audio, add score
        }

        if (collision.CompareTag("Timeline"))
        {
            stage = 1;
            //Debug.Log(stage);

            //when timeline went to beats and player on the beats
            playerObj = GameObject.FindGameObjectWithTag("Player");

            if(Vector2.Distance(transform.position, playerObj.transform.position) == 0
                || Vector2.Distance(transform.position, shadowObj.transform.position) <= 0.2f)
            {
                beatsVisual.sprite = touchedSprite;
                //GetComponent<SpriteRenderer>().sprite = touchedSprite;
                getBeats.Invoke(gameObject);
            }
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
