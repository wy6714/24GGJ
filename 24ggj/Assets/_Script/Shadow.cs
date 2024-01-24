using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float shawdowDelay = 0.5f;

    private bool canMoveShadow = true;
    void Update()
    {
        
        StartCoroutine(shadowMovement());
    }

    IEnumerator shadowMovement()
    {
        while (true)
        {
            if (canMoveShadow)
            {
                float horizontal = Input.GetAxisRaw("Horizontal");
                float vertical = Input.GetAxisRaw("Vertical");
                Rigidbody2D rb = GetComponent<Rigidbody2D>();

                rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);

                canMoveShadow = false;

                yield return new WaitForSeconds(shawdowDelay);

                canMoveShadow = true;
            }

            yield return null;
        }
    }
}
