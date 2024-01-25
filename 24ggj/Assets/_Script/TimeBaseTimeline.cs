using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBaseTimeline : MonoBehaviour
{
    public Transform StartPos;
    public Transform EndPos;

    public float moveSpeed = 50.0f;
    private float timer = 0.0f;

    public bool timeLineMove = false;

    public static event Action<GameObject> touchEndline;//gm

    private void OnEnable()
    {
        //shadowObj.SetActive(false);
        PlayerKeyUp.touchStartLine += touchStartLine;
    }

    private void OnDisable()
    {
        PlayerKeyUp.touchStartLine -= touchStartLine;
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timeLineMove && timer >= 0.5f)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

            timer = 0.0f;
            //Debug.Log(this.transform.position);
        }

        /*
        if (this.transform.position.x >= 11f)
        {
            moveSpeed = 0f;
        }
        */

        //timeline get to the end: 1)back start 2)invoke touchend event
        if (Vector2.Distance(transform.position, EndPos.position) <= 0)
        {
            timeLineMove = false;
            transform.position = StartPos.position;
            touchEndline?.Invoke(gameObject);

        }
    }

    public void touchStartLine(GameObject startLineObj)
    {
        timeLineMove = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(StartPos.position, new Vector3(0.2f, 15f, 0f));
        Gizmos.DrawWireCube(EndPos.position, new Vector3(0.2f, 15f, 0f));
    }
}
