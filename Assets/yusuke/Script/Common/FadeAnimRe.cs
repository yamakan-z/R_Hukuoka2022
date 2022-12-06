using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeAnimRe : MonoBehaviour
{
    public GameObject Panelfade; //フェードパネルの取得

    Image fadealpha; //フェードパネルのイメージ取得変数

    private float alpha; //パネルのalpha値取得変数

    private bool fadeout; //フェードアウトのフラグ変数
    private bool fadein; //フェードインのフラグ変数

    private void Start()
    {
        fadealpha = Panelfade.GetComponent<Image>(); //パネルのイメージ取得
        alpha = fadealpha.color.a; //パネルのalpha値を取得
        fadein = true; //シーン読み込み時にフェードインさせる
    }

    private void Update()
    {
        if(fadein==true)
        {
            FadeIn();
        }

        if(fadeout==true)
        {
            FadeOut();
        }
    }

    void FadeIn()
    {
        alpha -= 0.1f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if(alpha<=0)
        {
            fadein = false;
            Panelfade.SetActive(false);
        }
    }

    void FadeOut()
    {
        alpha += 0.1f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if(alpha>=1)
        {
            fadeout = false;
            SceneManager.LoadScene("MainScene");
        }
    }

    public void SceneMove()
    {
        fadeout = true;
        Panelfade.SetActive(true);
    }
}
