using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontal;
    private float vertical;

    private Rigidbody2D rb;

    public float moveSpeed = 8f;

    public GameObject startLine;

    //shadow
    public Vector2 lastPosition;
    private float shadowDelay = 8f;
    public GameObject shadowObj;

    //touch startline: 1)show shadow, 2)timeline start move
    public static event Action<GameObject> touchStartLine;//timeline script

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //shadow
        StartCoroutine(UpdateShadowPosition());
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("StartLine"))
        {
            touchStartLine?.Invoke(collision.gameObject);
        }

    }

    IEnumerator UpdateShadowPosition()
    {
        while (true)
        {
            shadowObj.transform.position = lastPosition;
            yield return new WaitForSeconds(shadowDelay);
        }

        

        
    }

    private void LateUpdate()
    {
        lastPosition = transform.position;
    }
}
