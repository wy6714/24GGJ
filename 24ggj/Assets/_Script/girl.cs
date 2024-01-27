using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class girl : MonoBehaviour
{
    public int stage = 0;
    public static event Action<GameObject> getBonus;

    private GameObject playerObj;
    private GameObject shadowObj;
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
            getBonus?.Invoke(gameObject);//play audio, add score
        }
        if (collision.CompareTag("Shadow") && stage == 1)
        {
            getBonus?.Invoke(gameObject);//play audio, add score
        }

        if (collision.CompareTag("Timeline"))
        {
            stage = 1;
            //Debug.Log(stage);

            //when timeline went to beats and player on the beats
            playerObj = GameObject.FindGameObjectWithTag("Player");
            //shadowObj = GameObject.FindGameObjectWithTag("Shadow");

            if (Vector2.Distance(transform.position, playerObj.transform.position) == 0)
            {
                getBonus.Invoke(gameObject);
            }
            //if (Vector2.Distance(transform.position, shadowObj.transform.position) == 0)
            //{
                //getBonus.Invoke(gameObject);
            //}
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Timeline"))
        {
            stage = 0;
        }
    }
}
