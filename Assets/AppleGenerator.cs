using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleGenerator : MonoBehaviour
{

    //applePrefabを入れる
    public GameObject applePrefab;

    //スタート地点
    private int startPos = 80;

    //ゴール地点
    private int goalPos = 210;

    //アイテムを出すx方向の範囲
    private float posRange = 1.3f;

    // Start is called before the first frame update
    void Start()
    {
        //一定の距離ごとにアイテムを生成
        for (int i = startPos; i < goalPos; i += 15)
        {
            //レーンごとにアイテムを生成
            for (int j = -1; j <= 1; j++)
            {

                //アイテムを置くZ座標のオフセットをランダムに設定
                int offsetZ = Random.Range(-6, 6);

                //リンゴを生成
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
