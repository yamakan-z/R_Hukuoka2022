using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    public GameObject Ranking;//ランキング画面を入れる

    [SerializeField]
    private int Score;//プレイ時の生存時間をここに入れる

    //ランキングデータ保持のための配列
    public int[] RankingScore = new int[5];//ここにランク入りした生存時間を入れる
    string[] ranking = { "Rank1", "Rank2", "Rank3", "Rank4", "Rank5" };

   
    public Text[] ScoreText;//生存時間を書きこむテキスト

    // Start is called before the first frame update
    void Start()
    {
        Ranking.SetActive(false);


        //ここでランキングの操作ができる
        //PlayerPrefs.SetInt("Rank1", 30);
        //PlayerPrefs.SetInt("Rank2", 25);
        //PlayerPrefs.SetInt("Rank3", 20);
        //PlayerPrefs.SetInt("Rank4", 15);
        //PlayerPrefs.SetInt("Rank5", 10);
        //PlayerPrefs.Save();



        UpdataRanking();

    }

    //ランキングの更新
    public void UpdataRanking()
    {
        Score = PlayerPrefs.GetInt("TEST", 0);

        
        //保存したランキングを呼び出す
        for (int i = 0; i < 5; i++)
        {
            RankingScore[i] = PlayerPrefs.GetInt(ranking[i], 0);
        }

        //呼び出したランキングと獲得したスコアを比較し入れ替える
        for (int i = 0; i < 5; i++)
        {
            if(Score >= RankingScore[i])
            {
                var change = RankingScore[i];
                RankingScore[i] = Score;
                Score = change;
            }
        }

        //入れ替えた値を保存
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt(ranking[i], RankingScore[i]);
            PlayerPrefs.Save();

            ScoreText[i].text = RankingScore[i].ToString()+"秒"; 
        }

        PlayerPrefs.SetInt("TEST", 0);//獲得したスコアの初期化
    }


    //ランキングボタンが押されたとき
    public void OnTapRankingButton()
    {
        Ranking.SetActive(true);

    }

    public void OnTapBackButton()
    {
        Ranking.SetActive(false);
    }

}
