using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource getBeatsAudio;
    [SerializeField] private AudioSource bgmAudio;
    private void OnEnable()
    {
        Beats.getBeats += getBeats;
        PlayerKeyUp.playBgm += playBgm;
        
    }

    private void OnDisable()
    {
        Beats.getBeats -= getBeats;
        PlayerKeyUp.playBgm -= playBgm;


    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void getBeats(GameObject beatObj)
    {
        Beats beatsScript = beatObj.GetComponent<Beats>();
        if (!beatsScript.hasget)//ensure beats audio only play once
        {
            getBeatsAudio.Play();
            beatsScript.hasget = true;
        }
    }

    public void playBgm(GameObject playerObj)
    {
        bgmAudio.Play();
    }

}
