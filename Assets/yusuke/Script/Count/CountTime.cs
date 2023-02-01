using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountTime : MonoBehaviour
{
    //カウントアップ
    [Header("生存時間が入る")]
    public float countup = 0.0f;

    //時間を表示するText型の変数
    public Text timeText;

    [SerializeField]private int tentime = 10;//10秒ごとに秒数経過のテキストを出させるよう

    [SerializeField]
    private float extime;//30秒毎のボイスを出す用

   [SerializeField] private AudioSource audio;

    [SerializeField] private AudioClip[] se;

    private void Start()
    {
        timeText.text = "";//テキスト初期化
    }

    private void Update()
    {
        //時間をカウントする
        countup += Time.deltaTime;

        extime += Time.deltaTime;

        if (countup >= tentime)
        {
            if(extime >= 30.0f)
            {
                audio.PlayOneShot(se[1]);
                extime = 0;
            }
            else
            {
                audio.PlayOneShot(se[0]);
            }

            Debug.Log("時間");
           
            timeText.text = tentime.ToString()+"秒経過！！";
            tentime += 10;
            Invoke("TimeText_Write", 2.0f);//二秒後にテキスト非表示
        }

        
    }

    void TimeText_Write()
    {
        timeText.text = "";//テキスト初期化
    }

}
