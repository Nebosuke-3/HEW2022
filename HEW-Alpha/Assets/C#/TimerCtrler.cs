using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerCtrler : MonoBehaviour
{
    AudioSource asou;

    public Text timerText;

    public string stageName;
    public float totalTime;
    int seconds;

    // Use this for initialization
    void Start()
    {
        asou = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;
        seconds = (int)totalTime;
        timerText.text = seconds.ToString();
        if (seconds < 60)
        {
            //Debug.Log("asooooooooooo");
            asou.Play();
        }
        if (seconds <= 0)
        {
            print(stageName);
            SceneManager.LoadScene(stageName);
        }

    }
}