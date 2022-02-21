using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Rigidbodyコンポーネントが必須
[RequireComponent(typeof(Rigidbody))]

public class MoveEnemy : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    AudioSource asou;

    [Header("プレイヤーオブジェクト名")]
    public string playerObjName = "Player_AS"; //プレイヤーオブジェクト名
    GameObject playerObj;
    
    Transform playerTransform;

    [Header("移動速度")]
    public float speed = 500.0f;

    public static int flug = 0;

    int count = 0;

    void Start()
    {
        anim = this.GetComponent<Animator>(); //Animatorコンポーネントを取得

        //Rigidbodyコンポーネントを取得する
        rb = this.GetComponent<Rigidbody>();
        if (rb == null) //rididbodyが見つからなければエラー
        {
            Debug.LogError("Rigidbodyが見つかりません");
            return;
        }

        //プレイヤーオブジェクトを取得する
        playerObj = GameObject.Find("PlayerHitBox");
        

        if (playerObj == null) //プレイヤーオブジェクトが見つからなければエラー
        {
            Debug.LogError("プレイヤーキャラクターが見つかりません");
            return;
        }
        playerTransform = playerObj.transform; //プレイヤーのtransformを取得

    }

    void Update()
    {
        Debug.Log(flug);
        if(flug == 1)
        {
            Vector3 moveForward = Vector3.forward * speed * Time.deltaTime;
            rb.velocity = new Vector3(moveForward.x, rb.velocity.y, moveForward.z); //XとZ方向に移動度を適用させる

            //プレイヤーキャラクターの方向を向く
            this.transform.LookAt(playerTransform.position);
            this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
        }
    }

    void FixedUpdate()
    {
        if (count <= 180 && flug == 0)
            count++;
        if (count > 180 && flug == 0)
        {
            StartCoroutine(RotatePlayerSlowly(Random.Range(-50.0f, 50.0f)));

            count = 0;
        }
    }


    IEnumerator RotatePlayerSlowly(float distance)
    {
        Vector3 step = new Vector3(0, distance / 30.0f, 0);
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.02f);
            transform.Rotate(step);
        }
    }
    public void shoot()
    {
        anim.SetInteger("Animation", 4);
    }
    public void idle()
    {
        anim.SetInteger("Animation", 1);
    }
}
