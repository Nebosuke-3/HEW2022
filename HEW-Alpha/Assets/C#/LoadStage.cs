using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStage : MonoBehaviour
{
    public string stageName;

    public void Click()
    {
        print(stageName);
        SceneManager.LoadScene(stageName);
    }
}
