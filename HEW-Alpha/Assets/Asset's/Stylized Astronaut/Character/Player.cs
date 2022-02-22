using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

		private Animator anim;
		private CharacterController controller;

		public float speed = 600.0f;
        public float jump;
        public float turnSpeed = 400.0f;
		private Vector3 moveDirection;
		public float gravity = 20.0f;

		void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
            Cursor.visible = false;
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
            transform.localScale = new Vector3(9, 5, 9);
        }
        else
        {
            transform.localScale = new Vector3(9, 10, 9);
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
