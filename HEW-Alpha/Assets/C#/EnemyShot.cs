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
    public int Rate; //50カウントで１秒

    GameObject enemyObject;

    void Start()
    {
        enemyObject = GameObject.Find("EnemyObj");

        asou = this.GetComponent<AudioSource>();

        count = 30;

        //---------------------------------
        Shooter = GameObject.Find("Shooter");//オブジェクトの名前から取得して変数に格納する
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

        //GetComponentでRigidbodyを取得して弾をcloneで生成します。
        rb = Instantiate(bullet, transform.position, transform.rotation).GetComponent<Rigidbody>();
        //前方向にthrustの数字の分一度だけ力を加えます。
        rb.AddForce(transform.forward * thrust, ForceMode.Impulse);
        asou.Play();//銃声再生

        yield return new WaitForSeconds(0.04f);
        //GetComponentでRigidbodyを取得して弾をcloneで生成します。
        rb = Instantiate(bullet, transform.position, transform.rotation).GetComponent<Rigidbody>();
        //前方向にthrustの数字の分一度だけ力を加えます。
        rb.AddForce(transform.forward * thrust, ForceMode.Impulse);
        asou.Play();//銃声再生

        yield return new WaitForSeconds(0.04f);
        //GetComponentでRigidbodyを取得して弾をcloneで生成します。
        rb = Instantiate(bullet, transform.position, transform.rotation).GetComponent<Rigidbody>();
        //前方向にthrustの数字の分一度だけ力を加えます。
        rb.AddForce(transform.forward * thrust, ForceMode.Impulse);
        asou.Play();//銃声再生

        yield return new WaitForSeconds(0.04f);
        //GetComponentでRigidbodyを取得して弾をcloneで生成します。
        rb = Instantiate(bullet, transform.position, transform.rotation).GetComponent<Rigidbody>();
        //前方向にthrustの数字の分一度だけ力を加えます。
        rb.AddForce(transform.forward * thrust, ForceMode.Impulse);
        asou.Play();//銃声再生

        yield return new WaitForSeconds(0.2f);
        enemyObject.GetComponent<MoveEnemy>().idle();

    }

}
