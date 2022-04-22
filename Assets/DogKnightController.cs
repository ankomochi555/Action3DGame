using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogKnightController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    private Animator myAnimator;

    // Use this for initialization
    void Start ()
    {
        //Animatorコンポーネントを取得
        this.myAnimator = GetComponent<Animator>();

        //走るアニメーションを開始
        this.myAnimator.SetFloat ("Speed", 1);
    }

    void Update ()
    {
		//マウスクリック
		if( Input.GetMouseButtonDown(0))
		{
			//タイプセレクト
			this.myAnimator.SetInteger( "Type", 2);

			//斬るアニメーションの開始（トリガー）
			this.myAnimator.SetTrigger("Attack");
		}
    }
}
