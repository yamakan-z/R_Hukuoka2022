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


    public int c;

    // Start is called before the first frame update
    void Start()
    {
        Ranking.SetActive(false);

        UpdataRanking();

    }

    //ランキングの更新
    public void UpdataRanking()
    {
        Score = PlayerPrefs.GetInt("TEST", 0);

        
        for (int i = 0; i < 5; i++)
        {
            RankingScore[i] = PlayerPrefs.GetInt("TEST", 0);
        }

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
