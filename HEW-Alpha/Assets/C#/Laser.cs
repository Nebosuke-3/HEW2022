using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    AudioSource asou;

    public string charaName = "Player_AS";//キャラクターオブジェクト名

    int counter = 0;
    float move = 0.04f;


    //Rigidbodyを含むオブジェクトがぶつかってきたら実行 
    void OnTriggerEnter(Collider col)
    {


        //ぶつかってきたオブジェクトがキャラクターなら
        if (col.gameObject.name == charaName)
        {
 //        Debug.Log("bbb");
           asou.Play();//ブザー音再生
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    asou = this.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = new Vector3(0, 0, move);
        transform.Translate(p);
        counter++;

        //countが500になれば-1を掛けて逆方向に動かす
        if (counter == 500)
        {
            counter = 0;
            move *= -1;
        }
    }
}
