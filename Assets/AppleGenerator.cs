using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleGenerator : MonoBehaviour
{

    //applePrefab������
    public GameObject applePrefab;

    //�X�^�[�g�n�_
    private int startPos = 20;

    //�S�[���n�_
    private int goalPos = 300;

    //�A�C�e�����o��x�����͈̔�
    private float posRange = 1.3f;

    // Start is called before the first frame update
    void Start()
    {
        //���̋������ƂɃA�C�e���𐶐�
        for (int i = startPos; i < goalPos; i += 5)
        {
			/*
            //���[�����ƂɃA�C�e���𐶐�
            for (int j = -1; j <= 1; j++)
            {
                //�A�C�e����u��Z���W�̃I�t�Z�b�g�������_���ɐݒ�
                //int offsetZ = Random.Range(-6, 6);

                //�����S�𐶐�
                GameObject apple = Instantiate(applePrefab);
                //apple.transform.position = new Vector3(posRange * j, apple.transform.position.y, i + offsetZ);
				apple.transform.position = new Vector3(posRange * j, apple.transform.position.y, i);
            }
			*/

			//���� -1, 0, 1�̂����ꂩ
			int r = Random.Range( -1, 2);

			//�ׂ����@�@����
			if( i >= 215 && i <= 222) {
				//����
				r = 0;
			}

			//�ׂ����A�@�E��
			if( i >= 230 && i <= 237) {
				//�E��
				r = 1;
			}

            //�ׂ����B�@����
            if (i >= 245 && i <= 252)
            {
                //����
                r = -1;
            }

            //�ׂ����C�@����
            if (i >= 263 && i <= 270)
            {
                //����
                r = -1;
            }

            //�����S�𐶐� ��Prefab��Y���W�����̂܂܃X���[�����Ă���B
            GameObject apple = Instantiate(applePrefab);
			apple.transform.position = new Vector3(posRange * r, apple.transform.position.y, i);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
