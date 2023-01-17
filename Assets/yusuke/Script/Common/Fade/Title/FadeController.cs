using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    float fadeSpeed = 0.02f; //不透明度が変わるスピードを管理
    float red, green, blue, alfa; //パネルの色、不透明度を管理

    public bool isFadeOut = false; //フェードアウト処理の開始、完了を管理するフラグ
    public bool isFadeIn = false; //フェードイン処理の開始、完了を管理するフラグ
    public string changeScneneName; //フェードアウト処理後、シーン遷移する場合のシーン名

    Image fadeImage; //不透明度を変更するパネルのイメージ

    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFadeIn)
        {
            StartFadeIn();
        }

        if(isFadeOut)
        {
            StartFadeOut();
        }
    }

    void StartFadeIn()
    {
        alfa -= fadeSpeed; //a不透明度を徐々に下げる
        SetAlpha(); //b変更した不透明度パネルに反映する
        if(alfa<=0)
        {
            //c完全に透明になったら処理を抜ける
            isFadeIn = false;
            fadeImage.enabled = false; //dパネルの表示をオフにする
        }
    }

    void StartFadeOut()
    {
        fadeImage.enabled = true; //aパネルの表示をオンにする
        alfa += fadeSpeed; //b不透明度を徐々に上げる
        SetAlpha(); //c変更した透明度をパネルに反映
        if(alfa>=1)
        {
            //d完全に不透明になったら処理を抜ける
            isFadeOut = false;

            if(changeScneneName!= "")
            {
                Debug.Log(changeScneneName+ "に遷移します。");
                SceneManager.LoadScene(changeScneneName);
            }
        }
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }

    //スタートボタンを押したら実行する
    public void GameStart()
    {
        isFadeOut = true;
        changeScneneName = "MainScene";
    }
}
