using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{

    //������̃I�u�W�F�N�g
    private GameObject dogknight;
    //������ƃJ�����̋���
    private float difference;


    // Start is called before the first frame update
    void Start()
    {
        //������̃I�u�W�F�N�g���擾
        this.dogknight = GameObject.Find("DogKnight");
        //������ƃJ�����̈ʒu�iz���W�j�̍������߂�
        this.difference = dogknight.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //������̈ʒu�ɍ��킹�ăJ�����̈ʒu���ړ�
        this.transform.position = new Vector3(0, this.transform.position.y, this.dogknight.transform.position.z - difference);
    }
}
