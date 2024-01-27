using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyUp : MonoBehaviour
{
    private float moveDis = 1f;

    private GameObject[] obstacles;

    private Vector2 newPos;

    //touch startline: 1)show shadow, 2)timeline start move
    public static event Action<GameObject> touchStartLine;//timeline script
    public static event Action<Vector2> RecordShadowMove;//GM
    public static event Action<GameObject> playBgm;

    private void OnEnable()
    {
        Portal.portalTransfer += portalTransfer;
    }

    private void OnDisable()
    {
        Portal.portalTransfer -= portalTransfer;
    }

    // Start is called before the first frame update
    void Start()
    {
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        newPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("StartLine"))
        {
            touchStartLine?.Invoke(collision.gameObject);
            playBgm?.Invoke(gameObject);
        }

    }

    public bool Blocked(Vector2 newPos)
    {
        foreach(var obj in obstacles)
        {
            if(obj.transform.position.x == newPos.x
                && obj.transform.position.y == newPos.y)
            {
                return true;
            }
        }

        return false;
    }

    public void move()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            newPos = transform.position;
            newPos.y = newPos.y + moveDis;

            if (!Blocked(newPos))
            {
                transform.position = newPos;
                RecordShadowMove?.Invoke(this.transform.position);
                
            }
            else
            {
                newPos = transform.position;
            }
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            newPos = transform.position;
            newPos.y = newPos.y - moveDis;

            if (!Blocked(newPos))
            {
                transform.position = newPos;
                RecordShadowMove?.Invoke(this.transform.position);
                
            }
            else
            {
                newPos = transform.position;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            newPos = transform.position;
            newPos.x = newPos.x - moveDis;

            if (!Blocked(newPos))
            {
                transform.position = newPos;
                RecordShadowMove?.Invoke(this.transform.position);
                
            }
            else
            {
                newPos = transform.position;
            }
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            newPos = transform.position;
            newPos.x = newPos.x + moveDis;

            if (!Blocked(newPos))
            {
                transform.position = newPos;
                RecordShadowMove?.Invoke(this.transform.position);
            }
            else
            {
                newPos = transform.position;
            }
        }

    }

    public void portalTransfer(Vector2 DestPos)
    {
        transform.position = DestPos;
    }

}
