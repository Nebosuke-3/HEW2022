using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Rigidbody�R���|�[�l���g���K�{
[RequireComponent(typeof(Rigidbody))]

public class MoveEnemy : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    AudioSource asou;

    [Header("�v���C���[�I�u�W�F�N�g��")]
    public string playerObjName = "Player_AS"; //�v���C���[�I�u�W�F�N�g��
    GameObject playerObj;
    
    Transform playerTransform;

    [Header("�ړ����x")]
    public float speed = 500.0f;

    public static int flug = 0;

    int count = 0;

    void Start()
    {
        anim = this.GetComponent<Animator>(); //Animator�R���|�[�l���g���擾

        //Rigidbody�R���|�[�l���g���擾����
        rb = this.GetComponent<Rigidbody>();
        if (rb == null) //rididbody��������Ȃ���΃G���[
        {
            Debug.LogError("Rigidbody��������܂���");
            return;
        }

        //�v���C���[�I�u�W�F�N�g���擾����
        playerObj = GameObject.Find("PlayerHitBox");
        

        if (playerObj == null) //�v���C���[�I�u�W�F�N�g��������Ȃ���΃G���[
        {
            Debug.LogError("�v���C���[�L�����N�^�[��������܂���");
            return;
        }
        playerTransform = playerObj.transform; //�v���C���[��transform���擾

    }

    void Update()
    {
        Debug.Log(flug);
        if(flug == 1)
        {
            Vector3 moveForward = Vector3.forward * speed * Time.deltaTime;
            rb.velocity = new Vector3(moveForward.x, rb.velocity.y, moveForward.z); //X��Z�����Ɉړ��x��K�p������

            //�v���C���[�L�����N�^�[�̕���������
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
