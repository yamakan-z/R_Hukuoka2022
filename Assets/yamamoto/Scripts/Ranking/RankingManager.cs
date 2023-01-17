using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    public GameObject Ranking;//ランキング画面を入れる

    public int[] RankingScore = new int[10];//ここにランク入りした生存時間を入れる

    [SerializeField]
    private int Score;//生存時間をここに入れる

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
