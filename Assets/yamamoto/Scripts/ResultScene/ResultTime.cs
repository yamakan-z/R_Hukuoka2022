using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResultTime : MonoBehaviour
{
    [SerializeField, Header("生存時間テキスト")]
    private Text scoretext;

    [SerializeField]
    private int score;//ここに保存した生存時間を入れる


    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("TEST", 0);
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "<color=#FFFFFF>あなたは</color>" + score.ToString()+ "秒<color=#FFFFFF>生き残った！！</color>";
        //ここで秒数を反映（カラーコード指定で一部の文字の色変更）

        //scoretext.text = "00:"+score.ToString();//ここで秒数を反映
    }
}
