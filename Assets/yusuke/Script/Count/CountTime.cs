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

    private void Update()
    {
        //時間をカウントする
        countup += Time.deltaTime;

        //時間を表示する
        timeText.text = countup.ToString("00:00");

        if(countup==0)
        {
            SceneManager.LoadScene("Result");
        }
    }
}
