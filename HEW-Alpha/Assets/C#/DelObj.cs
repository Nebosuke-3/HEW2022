using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelObj : MonoBehaviour
{
    public void Click()
    {
        GameObject obj = GameObject.Find("BGM");
        // 指定したオブジェクトを削除
        Destroy(obj);
    }
}
