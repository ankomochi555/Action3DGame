using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleGenerator : MonoBehaviour
{

    //applePrefab������
    public GameObject applePrefab;

    //�X�^�[�g�n�_
    private int startPos = 80;

    //�S�[���n�_
    private int goalPos = 210;

    //�A�C�e�����o��x�����͈̔�
    private float posRange = 1.3f;

    // Start is called before the first frame update
    void Start()
    {
        //���̋������ƂɃA�C�e���𐶐�
        for (int i = startPos; i < goalPos; i += 15)
        {
            //���[�����ƂɃA�C�e���𐶐�
            for (int j = -1; j <= 1; j++)
            {

                //�A�C�e����u��Z���W�̃I�t�Z�b�g�������_���ɐݒ�
                int offsetZ = Random.Range(-6, 6);

                //�����S�𐶐�
                GameObject apple = Instantiate(applePrefab);
                apple.transform.position = new Vector3(posRange * j, apple.transform.position.y, i + offsetZ);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
