using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelObj : MonoBehaviour
{
    public void Click()
    {
        GameObject obj = GameObject.Find("BGM");
        // �w�肵���I�u�W�F�N�g���폜
        Destroy(obj);
    }
}
