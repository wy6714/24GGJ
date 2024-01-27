using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckLevelPass : MonoBehaviour
{
    //public int normalPassScore;
    //public int currentScore = 0;
    //public TMP_Text ScoreText;
    // Start is called before the first frame update
    private void OnEnable()
    {
        //Beats.getBeats += addScore;
        //ScoreText.text = "Score: 0/" + normalPassScore.ToString();
    }

    private void OnDisable()
    {
        //Beats.getBeats -= addScore;
    }
    // Update is called once per frame
    void Update()
    {
        //ScoreText.text = "Score: " + currentScore.ToString() + "/" + normalPassScore.ToString();
        ////check pass condition
        //if(currentScore == normalPassScore)
        //{
        //    SceneManager.LoadScene("nomralWin");
        //}
    }

    //public void addScore(GameObject beatObj)
    //{
    //    Beats beatsScript = beatObj.GetComponent<Beats>();
    //    if (!beatsScript.hasget)//ensure beats audio only play once
    //    {
    //        currentScore = currentScore + beatsScript.score;
    //        Debug.Log("get" + beatsScript.score);
    //        beatsScript.hasget = true;
    //    }
    //}
}
