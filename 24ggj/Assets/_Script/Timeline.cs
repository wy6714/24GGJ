using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeline : MonoBehaviour
{
    public float moveSpeed = 3f;
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

    void Update()
    {
        if (timeLineMove)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime); 
        }
        
    }

    //when touch startline, 1)show shadow 2)timeline starts move
    public void touchStartLine(GameObject startLineObj)
    {
        timeLineMove = true;
        shadowObj.SetActive(true);

    }
}
    
