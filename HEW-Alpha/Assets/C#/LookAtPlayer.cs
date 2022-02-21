using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    GameObject playerObj;
    Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("PlayerHitBox");
        if (playerObj == null) //プレイヤーオブジェクトが見つからなければエラー
        {
            Debug.LogError("プレイヤーキャラクターが見つかりません");
            return;
        }
        playerTransform = playerObj.transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(playerTransform.position);//プレイヤーのほうを見る
    }
}
