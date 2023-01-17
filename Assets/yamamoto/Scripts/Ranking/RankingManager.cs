using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    public GameObject Ranking;//�����L���O��ʂ�����

    public int[] RankingScore = new int[10];//�����Ƀ����N���肵���������Ԃ�����

    [SerializeField]
    private int Score;//�������Ԃ������ɓ����

    // Start is called before the first frame update
    void Start()
    {
        Ranking.SetActive(false);

        UpdataRanking();

    }

    //�����L���O�̍X�V
    public void UpdataRanking()
    {
        Score = PlayerPrefs.GetInt("TEST", 0);
    }
   

    //�����L���O�{�^���������ꂽ�Ƃ�
    public void OnTapRankingButton()
    {
        Ranking.SetActive(true);
    }

    public void OnTapBackButton()
    {
        Ranking.SetActive(false);
    }

}
