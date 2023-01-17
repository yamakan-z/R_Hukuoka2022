using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    public GameObject Ranking;//�����L���O��ʂ�����

    [SerializeField]
    private int Score;//�v���C���̐������Ԃ������ɓ����

    //�����L���O�f�[�^�ێ��̂��߂̔z��
    public int[] RankingScore = new int[5];//�����Ƀ����N���肵���������Ԃ�����
    string[] ranking = { "Rank1", "Rank2", "Rank3", "Rank4", "Rank5" };

   
    public Text[] ScoreText;//�������Ԃ��������ރe�L�X�g


    public int c;

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

        
        for (int i = 0; i < 5; i++)
        {
            RankingScore[i] = PlayerPrefs.GetInt("TEST", 0);
        }

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
