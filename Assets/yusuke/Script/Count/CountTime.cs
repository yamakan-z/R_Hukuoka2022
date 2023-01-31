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

    [SerializeField] private AudioSource audio;

    [SerializeField] private AudioClip se;

    private void Start()
    {
        timeText.text = "";//テキスト初期化
    }

    private void Update()
    {
        //時間をカウントする
        countup += Time.deltaTime;

        if(countup >= tentime)
        {
            Debug.Log("時間");
            audio.PlayOneShot(se);
            timeText.text = tentime.ToString()+"秒経過！！";
            tentime += 10;
        }

        
    }
}
