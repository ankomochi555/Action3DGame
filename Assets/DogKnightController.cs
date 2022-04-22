using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogKnightController : MonoBehaviour
{
    //�A�j���[�V�������邽�߂̃R���|�[�l���g������
    private Animator myAnimator;

    // Use this for initialization
    void Start ()
    {
        //Animator�R���|�[�l���g���擾
        this.myAnimator = GetComponent<Animator>();

        //����A�j���[�V�������J�n
        this.myAnimator.SetFloat ("Speed", 1);
    }

    void Update ()
    {
		//�}�E�X�N���b�N
		if( Input.GetMouseButtonDown(0))
		{
			//�^�C�v�Z���N�g
			this.myAnimator.SetInteger( "Type", 2);

			//�a��A�j���[�V�����̊J�n�i�g���K�[�j
			this.myAnimator.SetTrigger("Attack");
		}
    }
}
