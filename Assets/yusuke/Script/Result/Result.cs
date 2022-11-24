using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    private float step_time; //経過時間カウント用

    private void Start()
    {
        step_time = 0.0f; //経過時間初期化
    }

    private void Update()
    {
        //経過時間をカウント
        step_time += Time.deltaTime;

        //3秒後に画面遷移
        if(step_time>=3.0f)
        {
            SceneManager.LoadScene("Title");
        }
    }
}
