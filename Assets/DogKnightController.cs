using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //�i�ǉ��j


public class DogKnightController : MonoBehaviour
{
    //�A�j���[�V�������邽�߂̃R���|�[�l���g������
    private Animator myAnimator;

    //DogKnight���ړ�������R���|�[�l���g������i�ǉ��j
    private Rigidbody myRigidbody;

    //�O�����̑��x
    private float velocityZ = 9f;

    //�������̑��x
    private float velocityX = 7f;

    //���E�̈ړ��ł���͈�
    private float movableRange = 1.5f;

    //����������������W��
    private float coefficient = 0.99f;

    //�Q�[���I���̔���
    private bool isEnd = false;

    //�Q�[���I�����ɕ\������e�L�X�g�i�ǉ��j
    private GameObject stateText;

    //�X�R�A��\������e�L�X�g�i�ǉ��j
    private GameObject scoreText;

    //���_�i�ǉ��j
    private int score = 0;

    //���ʉ��̓o�^
    public AudioClip appleSE;
    public AudioClip gameOverSE;
    public AudioClip gameClearSE;

    // Use this for initialization
    void Start ()
    {
        //Animator�R���|�[�l���g���擾
        this.myAnimator = GetComponent<Animator>();

        //����A�j���[�V�������J�n
        this.myAnimator.SetFloat ("Speed", 1);

        //Rigidbody�R���|�[�l���g���擾
        this.myRigidbody = GetComponent<Rigidbody>();

        //�V�[������stateText�I�u�W�F�N�g���擾�i�ǉ��j
        this.stateText = GameObject.Find("ResultText");

        //�V�[������scoreText�I�u�W�F�N�g���擾�i�ǉ��j
        this.scoreText = GameObject.Find("ScoreText");

    }

    void Update ()
    {
        /*
        //�}�E�X�N���b�N
		if( Input.GetMouseButtonDown(0))
		{
			//�^�C�v�Z���N�g
			this.myAnimator.SetInteger( "Type", 2);

			//�a��A�j���[�V�����̊J�n�i�g���K�[�j
			this.myAnimator.SetTrigger("Attack");
		}
        */

        //�Q�[���I���Ȃ猢����̓�������������
        if (this.isEnd)
        {
			//����
            this.velocityZ *= this.coefficient;
            this.velocityX *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }

        //�������̓��͂ɂ�鑬�x
        float inputVelocityX = 0;

        //���L�[�܂��̓{�^���ɉ����č��E�Ɉړ�������
        if (Input.GetKey(KeyCode.LeftArrow) && -this.movableRange < this.transform.position.x)
        {
            //�������ւ̑��x����
            inputVelocityX = -this.velocityX;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < this.movableRange)
        {
            //�E�����ւ̑��x����
            inputVelocityX = this.velocityX;
        }

		//�Q�[���I���̃`�F�b�N ���n�ʂ�艺�֗����ā[1���ŃQ�[���[�o�[�A���� isEnd��true����Ȃ���
		if( this.transform.position.y < -1f && this.isEnd == false)
		{
            //���U���gUI�փQ�[���I�[�o�[��\��
            this.stateText.GetComponent<Text>().text = "Game Over";

            //���ʉ��i�Q�[���I�[�o�[�W���O���j
            GetComponent<AudioSource>().PlayOneShot(gameOverSE);

            //�����i�G���h�j
            this.isEnd = true;
		}

        //DogKnight�ɑ��x��^���� ���J���L�������ɖ����e�N�j�b�N�i�X���[�j
        this.myRigidbody.velocity = new Vector3(inputVelocityX, this.myRigidbody.velocity.y, velocityZ);
    }


    //�g���K�[���[�h�ő��̃I�u�W�F�N�g�ƐڐG�����ꍇ�̏���
    void OnTriggerEnter(Collider other)
    {
        //�S�[���n�_�ɓ��B�����ꍇ�A���� isEnd��true����Ȃ���
        if (other.gameObject.tag == "GoalTag" && this.isEnd == false)
        {
            //���U���gUI�փQ�[���N���A�[��\��
            this.stateText.GetComponent<Text>().text = "CLEAR!!";

            //���ʉ�
            GetComponent<AudioSource>().PlayOneShot(gameClearSE);

            //�����i�G���h�j
            this.isEnd = true;
        }

        //�����S�ɏՓ˂����ꍇ
        if (other.gameObject.tag == "AppleTag")
        {
            //�p�[�e�B�N�����Đ�
            GetComponent<ParticleSystem>().Play();

            // �X�R�A�����Z(�ǉ�)
            this.score += 10;

            //ScoreText�Ɋl�������_����\��(�ǉ�)
            this.scoreText.GetComponent<Text>().text = "Score " + this.score + "pt";

            //���ʉ�
            GetComponent<AudioSource>().PlayOneShot(appleSE);

            //�ڐG���������S�̃I�u�W�F�N�g��j��
            Destroy(other.gameObject);
        }
    }
}
