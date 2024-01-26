using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float x;
    public float y;

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
        TimeBaseTimeline.touchEndline += touchEndline;

        PlayerKeyUp.touchStartLine += touchStartLine;
    }

    private void OnDisable()
    {
        PlayerKeyUp.RecordShadowMove -= recordShadowMove;
        TimeBaseTimeline.touchEndline -= touchEndline;

        PlayerKeyUp.touchStartLine -= touchStartLine;

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
                playerCoords.Dequeue();
                printPlayerCoords();
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
        if (timeOn && round ==0)
        {
            timeStamp.Enqueue(timer);
            playerCoords.Enqueue(playerTrans);
            Debug.Log(playerTrans.position);
        }  
    }

    public void touchEndline(GameObject timelineObj)
    {//timeline at the end
        round += 1;
        Debug.Log("round:" + round + "is ready");
        timeOn = false;//stop timer
        timer = 0;//reset timer

        playerTransform.position = new Vector2(x, y);
    }

    
    public void touchStartLine(GameObject playerTrans)
    {//player touch startline and round>0
        timeOn = true;//start timer
        if (round > 0 && playerCoords.Count >0)
        {
            shadowObj.SetActive(true);
            ShadowMoveTime = timeStamp.Peek();
            isGoNextStamp = true;
        }
        
    }

    public void printPlayerCoords()
    {
        foreach(Transform trans in playerCoords)
        {
            Vector2 pos = trans.position;
            Debug.Log(pos);
        }
    }


   
}
