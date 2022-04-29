using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleGenerator : MonoBehaviour
{

    //applePrefabを入れる
    public GameObject applePrefab;

    //スタート地点
    private int startPos = 20;

    //ゴール地点
    private int goalPos = 300;

    //アイテムを出すx方向の範囲
    private float posRange = 1.3f;

    // Start is called before the first frame update
    void Start()
    {
        //一定の距離ごとにアイテムを生成
        for (int i = startPos; i < goalPos; i += 5)
        {
			/*
            //レーンごとにアイテムを生成
            for (int j = -1; j <= 1; j++)
            {
                //アイテムを置くZ座標のオフセットをランダムに設定
                //int offsetZ = Random.Range(-6, 6);

                //リンゴを生成
                GameObject apple = Instantiate(applePrefab);
                //apple.transform.position = new Vector3(posRange * j, apple.transform.position.y, i + offsetZ);
				apple.transform.position = new Vector3(posRange * j, apple.transform.position.y, i);
            }
			*/

			//乱数 -1, 0, 1のいずれか
			int r = Random.Range( -1, 2);

			//細い橋①　中央
			if( i >= 215 && i <= 222) {
				//中央
				r = 0;
			}

			//細い橋②　右側
			if( i >= 230 && i <= 237) {
				//右側
				r = 1;
			}

            //細い橋③　左側
            if (i >= 245 && i <= 252)
            {
                //左側
                r = -1;
            }

            //細い橋④　左側
            if (i >= 263 && i <= 270)
            {
                //左側
                r = -1;
            }

            //リンゴを生成 ※PrefabのY座標をそのままスルーさせている。
            GameObject apple = Instantiate(applePrefab);
			apple.transform.position = new Vector3(posRange * r, apple.transform.position.y, i);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
