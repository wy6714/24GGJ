using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBaseTimeline : MonoBehaviour
{
    public float moveSpeed = 50.0f; // Adjust the speed as needed
    private float timer = 0.0f;

    public bool timeLineMove = false;

    public GameObject shadowObj;

    private void OnEnable()
    {
        shadowObj.SetActive(false);
        Player.touchStartLine += touchStartLine;
    }

    private void OnDisable()
    {
        Player.touchStartLine -= touchStartLine;
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timeLineMove && timer >= 0.5f)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

            timer = 0.0f;
            Debug.Log(this.transform.position);
        }

        if(this.transform.position.x >= 11f)
        {
            moveSpeed = 0f;
        }
    }

    public void touchStartLine(GameObject startLineObj)
    {
        timeLineMove = true;
        shadowObj.SetActive(true);

    }
}
