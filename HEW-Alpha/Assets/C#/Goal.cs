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
        message.text = "�����鏀�������܂��BEnter�L�[�����̐�����10�ɂȂ�܂ŘA�ł��Ă��������B";
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
