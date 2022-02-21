using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actBullet : MonoBehaviour
{
    float startTime; //発射時刻
    void Start()
    {
        startTime = Time.time; //発射された時刻を覚えておく
    }

    void Update()
    {
        transform.position += transform.forward * startTime * Time.deltaTime;

        if (startTime + 1.0f < Time.time) //発射から3秒経ったら
        {
            Destroy(this.gameObject); //自身を削除
        }
    }

    //何かにぶつかったら
    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Player")
        {
            //Destroy(col.gameObject);//相手を削除


            //キャラクターの移動度をリセットする
            //col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //col.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            //キャラクターの位置を初期位置にする
            col.transform.position = new Vector3(1.7f, 1.0f, -14.0f);

            Destroy(this.gameObject); //自身を削除
        }
        Destroy(this.gameObject); //自身を削除
    }
}
