using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    AudioSource asou;

    public string charaName = "Player_AS";//�L�����N�^�[�I�u�W�F�N�g��

    int counter = 0;
    float move = 0.04f;


    //Rigidbody���܂ރI�u�W�F�N�g���Ԃ����Ă�������s 
    void OnTriggerEnter(Collider col)
    {


        //�Ԃ����Ă����I�u�W�F�N�g���L�����N�^�[�Ȃ�
        if (col.gameObject.name == charaName)
        {
 //        Debug.Log("bbb");
           asou.Play();//�u�U�[���Đ�
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

        //count��500�ɂȂ��-1���|���ċt�����ɓ�����
        if (counter == 500)
        {
            counter = 0;
            move *= -1;
        }
    }
}
