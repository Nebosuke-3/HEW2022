using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    AudioSource asou;
    Rigidbody rb;

    GameObject playerObj;
    Transform playerTransform;

    public GameObject bullet;

    public float thrust = 100f;

    GameObject Shooter;

    MoveEnemy MEscript;

    int MEflug;

    int count;
    public int Rate; //50�J�E���g�łP�b

    GameObject enemyObject;

    void Start()
    {
        enemyObject = GameObject.Find("EnemyObj");

        asou = this.GetComponent<AudioSource>();

        count = 30;

        //---------------------------------
        Shooter = GameObject.Find("Shooter");//�I�u�W�F�N�g�̖��O����擾���ĕϐ��Ɋi�[����
        MEscript = Shooter.GetComponent<MoveEnemy>();
        //---------------------------------

    }


    void FixedUpdate()
    {
        if (count <= Rate && MoveEnemy.flug ==1)
            count++;
        if (count > Rate && MoveEnemy.flug == 1)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        MEflug = 0;
        count = 0;
        enemyObject.GetComponent<MoveEnemy>().shoot();
        yield return new WaitForSeconds(0.3f);

        //GetComponent��Rigidbody���擾���Ēe��clone�Ő������܂��B
        rb = Instantiate(bullet, transform.position, transform.rotation).GetComponent<Rigidbody>();
        //�O������thrust�̐����̕���x�����͂������܂��B
        rb.AddForce(transform.forward * thrust, ForceMode.Impulse);
        asou.Play();//�e���Đ�

        yield return new WaitForSeconds(0.04f);
        //GetComponent��Rigidbody���擾���Ēe��clone�Ő������܂��B
        rb = Instantiate(bullet, transform.position, transform.rotation).GetComponent<Rigidbody>();
        //�O������thrust�̐����̕���x�����͂������܂��B
        rb.AddForce(transform.forward * thrust, ForceMode.Impulse);
        asou.Play();//�e���Đ�

        yield return new WaitForSeconds(0.04f);
        //GetComponent��Rigidbody���擾���Ēe��clone�Ő������܂��B
        rb = Instantiate(bullet, transform.position, transform.rotation).GetComponent<Rigidbody>();
        //�O������thrust�̐����̕���x�����͂������܂��B
        rb.AddForce(transform.forward * thrust, ForceMode.Impulse);
        asou.Play();//�e���Đ�

        yield return new WaitForSeconds(0.04f);
        //GetComponent��Rigidbody���擾���Ēe��clone�Ő������܂��B
        rb = Instantiate(bullet, transform.position, transform.rotation).GetComponent<Rigidbody>();
        //�O������thrust�̐����̕���x�����͂������܂��B
        rb.AddForce(transform.forward * thrust, ForceMode.Impulse);
        asou.Play();//�e���Đ�

        yield return new WaitForSeconds(0.2f);
        enemyObject.GetComponent<MoveEnemy>().idle();

    }

}
