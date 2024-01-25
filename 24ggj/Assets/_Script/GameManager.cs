using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject shadowObj;
    public Transform playerTransform;

    private float timer = 0.0f;
    private float ShadowMoveTime;

    private bool isGoNextStamp = false;
    private bool timeOn = false;

    private Queue<float> timeStamp = new Queue<float>();
    private Queue<Transform> playerCoords = new Queue<Transform>();

    private int round = 0;

    private void OnEnable()
    {
        PlayerKeyUp.RecordShadowMove += recordShadowMove;
        TimeBaseTimeline.touchEndline += addRound;

        PlayerKeyUp.touchStartLine += isShadowOn;
    }

    private void OnDisable()
    {
        PlayerKeyUp.RecordShadowMove -= recordShadowMove;
        TimeBaseTimeline.touchEndline -= addRound;

        PlayerKeyUp.touchStartLine -= isShadowOn;

    }
    void Start()
    {
        shadowObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeOn)
        {
            timer += Time.deltaTime;
            if (round >0 && playerCoords.Count > 0 && timer >= ShadowMoveTime)
            {
                shadowObj.transform.position = playerCoords.Dequeue().position;
                Debug.Log("shadow current pos is:" + shadowObj.transform.position
                    +"move at time:" + ShadowMoveTime);
                //ShadowMoveTime = timeStamp.Dequeue();
                isGoNextStamp = true;
            }
        }
        

        if (isGoNextStamp && timeStamp.Count>0)
        {
            ShadowMoveTime = timeStamp.Dequeue();
            Debug.Log("next player moved Time is:" + ShadowMoveTime);
            isGoNextStamp = false;
        }

        
    }

    public void recordShadowMove(Transform playerTrans)
    {
        if (timeOn)
        {
            timeStamp.Enqueue(timer);
            playerCoords.Enqueue(playerTrans);
        }
        
    }

    public void addRound(GameObject timelineObj)
    {//timeline at the end
        round += 1;
        Debug.Log("current Round:" + round);
        timeOn = false;//stop timer
        timer = 0;//reset timer

        printTimeStamp();
    }

    
    public void isShadowOn(GameObject playerTrans)
    {//player touch startline and round>0
        
        isGoNextStamp = true;
        timeOn = true;//start timer
        shadowObj.SetActive(true);
    }

    public void printTimeStamp()
    {
        Debug.Log("Queue Contents:");
        foreach (float time in timeStamp)
        {
            Debug.Log(time);
        }

        //foreach (Transform pos in playerCoords)
        //{
        //    Vector2 newpos = pos.position;
        //    Debug.Log(newpos);
        //}
    }

   
}
