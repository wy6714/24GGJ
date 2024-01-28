using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource getBeatsAudio;
    [SerializeField] private AudioSource bgmAudio;
    public Image originalGirl;
    public Image brightenGril;

    public int normalPassScore;
    public int currentScore = 0;
    public TMP_Text ScoreText;
    public bool isGetBonus = false;

    public GameObject girlObj;

    private void OnEnable()
    {
        originalGirl.enabled = true;//girl image
        brightenGril.enabled = false;

        Beats.getBeats += getBeats;
        PlayerKeyUp.playBgm += playBgm;

        TimeBaseTimeline.touchEndline += restartLevel;

        ScoreText.text = "Score: 0/" + normalPassScore.ToString();
        girl.getBonus += getBonus;

    }

    private void OnDisable()
    {
        Beats.getBeats -= getBeats;
        PlayerKeyUp.playBgm -= playBgm;

        TimeBaseTimeline.touchEndline -= restartLevel;
        girl.getBonus -= getBonus;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //score text
        ScoreText.text = "Score: " + currentScore.ToString() + "/" + normalPassScore.ToString();

        //bonus condition UI
        girlImage(isGetBonus);

        //check pass condition
        if (currentScore == normalPassScore)
        {//check get which ending
            if (isGetBonus)
            {
                SceneManager.LoadScene("bonusWin");
            }
            else
            {
                SceneManager.LoadScene("normalWin");
            }
            
        }
    }

    public void getBeats(GameObject beatObj)
    {
        Beats beatsScript = beatObj.GetComponent<Beats>();
        if (!beatsScript.hasget)//ensure beats audio only play once
        {
            getBeatsAudio.Play();//player audio
            //add score
            currentScore = currentScore + beatsScript.score;
            beatsScript.hasget = true;
        }
    }

    public void restartLevel(GameObject timelineObj)
    {
        if (currentScore < normalPassScore)
        {
            currentScore = 0;
            GameObject[] AllBeats = GameObject.FindGameObjectsWithTag("beats");
            foreach (GameObject beat in AllBeats)
            {
                Beats beatScirpt = beat.GetComponent<Beats>();
                beatScirpt.hasget = false;
            }

            //reset bonus
            isGetBonus = false;

        } 

}

    public void playBgm(GameObject playerObj)
    {
        bgmAudio.Play();
    }

    public void getBonus(GameObject girlObj)
    {
        isGetBonus = true;//check which ending

        girlObj.SetActive(false);//in case next round need to have gril back

    }

    public void girlImage(bool isgetBonus)
    {
        if (isgetBonus)
        {
            originalGirl.enabled = false;
            brightenGril.enabled = true;
            girlObj.SetActive(false);
        }
        else
        {
            originalGirl.enabled = true;
            brightenGril.enabled = false;
            girlObj.SetActive(true);
        }
    }

}
