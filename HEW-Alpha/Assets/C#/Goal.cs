using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public Text message;
    public string stageName;
    public float GoalKey;    
    public Text goalText;

    void OnTriggerStay(Collider other)
    {
        message.text = "逃げる準備をします。Enterキーを下の数字が10になるまで連打してください。";
        if (Input.GetKeyUp(KeyCode.Return))
        {
            GoalKey += 1;
            goalText.text = GoalKey.ToString();
            if (GoalKey == 10)
            {
                print(stageName);
                SceneManager.LoadScene(stageName);
            }
        }
    }
}
