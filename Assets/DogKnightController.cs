using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogKnightController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    private Animator myAnimator;

    //DogKnightを移動させるコンポーネントを入れる（追加）
    private Rigidbody myRigidbody;

    //前方向の速度
    private float velocityZ = 11f;

    //横方向の速度
    private float velocityX = 7f;

    //左右の移動できる範囲
    private float movableRange = 1.5f;

    //動きを減速させる係数
    private float coefficient = 0.99f;

    //ゲーム終了の判定
    private bool isEnd = false;

    // Use this for initialization
    void Start ()
    {
        //Animatorコンポーネントを取得
        this.myAnimator = GetComponent<Animator>();

        //走るアニメーションを開始
        this.myAnimator.SetFloat ("Speed", 1);

        //Rigidbodyコンポーネントを取得
        this.myRigidbody = GetComponent<Rigidbody>();
    }

    void Update ()
    {
        /*
        //マウスクリック
		if( Input.GetMouseButtonDown(0))
		{
			//タイプセレクト
			this.myAnimator.SetInteger( "Type", 2);

			//斬るアニメーションの開始（トリガー）
			this.myAnimator.SetTrigger("Attack");
		}
        */

        //ゲーム終了なら犬さんの動きを減衰する
        if (this.isEnd)
        {
			//減衰
            this.velocityZ *= this.coefficient;
            this.velocityX *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }

        //横方向の入力による速度
        float inputVelocityX = 0;

        //矢印キーまたはボタンに応じて左右に移動させる
        if (Input.GetKey(KeyCode.LeftArrow) && -this.movableRange < this.transform.position.x)
        {
            //左方向への速度を代入
            inputVelocityX = -this.velocityX;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < this.movableRange)
        {
            //右方向への速度を代入
            inputVelocityX = this.velocityX;
        }

		//ゲーム終了のチェック ※地面より下へ落ちてー1ｍでゲームーバー、かつ isEndがtrueじゃない時
		if( this.transform.position.y < -1f && this.isEnd == false)
		{
			//リザルトUIへゲームオーバーを表示


			//効果音（ゲームオーバージングル）


			//減衰（エンド）
			this.isEnd = true;
		}

        //DogKnightに速度を与える ※カリキュラムに無いテクニック（スルー）
        this.myRigidbody.velocity = new Vector3(inputVelocityX, this.myRigidbody.velocity.y, velocityZ);
    }

    //トリガーモードで他のオブジェクトと接触した場合の処理
    void OnTriggerEnter(Collider other)
    {
        //ゴール地点に到達した場合、かつ isEndがtrueじゃない時
        if (other.gameObject.tag == "GoalTag" && this.isEnd == false)
        {
			//リザルトUIへゲームクリアーを表示


			//効果音


			//減衰（エンド）
            this.isEnd = true;
        }

        //リンゴに衝突した場合
        if (other.gameObject.tag == "AppleTag")
        {
            //パーティクルを再生（追加）
            GetComponent<ParticleSystem>().Play();

			//効果音


            //接触したリンゴのオブジェクトを破棄
            Destroy(other.gameObject);
        }
    }
}
