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

        // 1.5�b�҂�
        yield return new WaitForSeconds(1.5f);
        message.text = "";
        turnSpeed = 150.0f;
        speed = 4.0f;
    }

    void Update (){
        //����
        if (Input.GetKey("w"))
        {
            anim.SetInteger("AnimationPar", 1);
        }
        else
        {
            anim.SetInteger("AnimationPar", 0);
        }
        //���Ⴊ��
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
                if (Input.GetKeyDown(KeyCode.Space))//  �����A�X�y�[�X�L�[�������ꂽ��A
                {
                    moveDirection.y = jump;//  y���W���W�����v�͂̕�����������
                }
        }   

			    float turn = Input.GetAxis("Horizontal");
			    transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			    controller.Move(moveDirection * Time.deltaTime);
			    moveDirection.y -= gravity * Time.deltaTime;

                moveDirection.y += Physics.gravity.y * Time.deltaTime; //���y���W���d�͂̕�����������(�d�͏���)
                controller.Move(moveDirection * Time.deltaTime); //CharacterControlloer��moveDirection�̕����ɓ�����
        }
}
