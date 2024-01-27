using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform DestinationTrans;
    public static event Action<Vector2> portalTransfer;//player scirpt
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

        if (collision.CompareTag("Player"))
        {
            portalTransfer?.Invoke(DestinationTrans.position);//player scirpt
        }

    }

}
