using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRay : MonoBehaviour
{
    Transform playerTransform;
    GameObject playerObj;

    [Header("����")]
    public float visionLength = 60.0f;//���쒷
    public float visionAngle = 120.0f;//����p

    void Start()
    {
        //�v���C���[�I�u�W�F�N�g���擾����
        playerObj = GameObject.Find("PlayerHitBox");


        if (playerObj == null) //�v���C���[�I�u�W�F�N�g��������Ȃ���΃G���[
        {
            Debug.LogError("�v���C���[�L�����N�^�[��������܂���");
            return;
        }
        playerTransform = playerObj.transform; //�v���C���[��transform���擾

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayVec = playerTransform.position - this.transform.position; //�G����v���C���[�ւ̕���


        float sa = Mathf.Abs(Vector3.Angle(rayVec, this.transform.forward));

        if (sa < visionAngle / 2)
        {
            //Debug.Log("Casting Ray");
            Ray ray = new Ray(this.transform.position + new Vector3(0.0f, 0.7f, 0.0f), rayVec);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, visionLength))
            {
                if (hit.transform.gameObject.name == "Player_AS")
                {
                    MoveEnemy.flug = 1;
                    //Debug.Log("one");
                   
                    Debug.DrawRay(ray.origin, ray.direction * visionLength, Color.red, 0.1f, false);
                }
                else
                {
                    MoveEnemy.flug = 0;
                    Debug.DrawRay(ray.origin, ray.direction * visionLength, Color.red, 0.1f, false);
                    //anim.SetInteger("Animation", 1);

                    //Debug.Log("eeeeeeeeeeeeeeeeeeee!!!!!!!!!!");
                }
            }
            else
            {
                MoveEnemy.flug = 0;
            }
        }
    }
}
