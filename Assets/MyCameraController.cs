using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{

    //犬さんのオブジェクト
    private GameObject dogknight;
    //犬さんとカメラの距離
    private float difference;


    // Start is called before the first frame update
    void Start()
    {
        //犬さんのオブジェクトを取得
        this.dogknight = GameObject.Find("DogKnight");
        //犬さんとカメラの位置（z座標）の差を求める
        this.difference = dogknight.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //犬さんの位置に合わせてカメラの位置を移動
        this.transform.position = new Vector3(0, this.transform.position.y, this.dogknight.transform.position.z - difference);
    }
}
