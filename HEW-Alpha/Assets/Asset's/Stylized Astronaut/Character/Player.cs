using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

		private Animator anim;
		private CharacterController controller;

		public float speed = 4.0f;
        public float jump;
        public float turnSpeed = 150.0f;
		private Vector3 moveDirection;
		public float gravity = 20.0f;
        public Text message;

    void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
            //Cursor.visible = false;
         }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            message.text = "PARALYZED!!!";
            StartCoroutine(DelayCoroutine());
        }
    }

    private IEnumerator DelayCoroutine()
    {
        speed = 0.0f;
        turnSpeed = 0.0f;

        // 1.5秒待つ
        yield return new WaitForSeconds(1.5f);
        message.text = "";
        turnSpeed = 150.0f;
        speed = 4.0f;
    }

    void Update (){
        //歩く
        if (Input.GetKey("w"))
        {
            anim.SetInteger("AnimationPar", 1);
        }
        else
        {
            anim.SetInteger("AnimationPar", 0);
        }
        //しゃがむ
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(8, 3, 8);
        }
        else
        {
            transform.localScale = new Vector3(8, 9, 8);
        }

        if (controller.isGrounded){
				moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
                if (Input.GetKeyDown(KeyCode.Space))//  もし、スペースキーがおされたら、
                {
                    moveDirection.y = jump;//  y座標をジャンプ力の分だけ動かす
                }
        }   

			    float turn = Input.GetAxis("Horizontal");
			    transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			    controller.Move(moveDirection * Time.deltaTime);
			    moveDirection.y -= gravity * Time.deltaTime;

                moveDirection.y += Physics.gravity.y * Time.deltaTime; //常にy座標を重力の分だけ動かす(重力処理)
                controller.Move(moveDirection * Time.deltaTime); //CharacterControlloerをmoveDirectionの方向に動かす
        }
}
