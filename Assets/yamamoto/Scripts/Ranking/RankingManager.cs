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

    // Start is called before the first frame update
    void Start()
    {
        Ranking.SetActive(false);


        //�����Ń����L���O�̑��삪�ł���
        //PlayerPrefs.SetInt("Rank1", 30);
        //PlayerPrefs.SetInt("Rank2", 25);
        //PlayerPrefs.SetInt("Rank3", 20);
        //PlayerPrefs.SetInt("Rank4", 15);
        //PlayerPrefs.SetInt("Rank5", 10);
        //PlayerPrefs.Save();



        UpdataRanking();

    }

    //�����L���O�̍X�V
    public void UpdataRanking()
    {
        Score = PlayerPrefs.GetInt("TEST", 0);

        
        //�ۑ����������L���O���Ăяo��
        for (int i = 0; i < 5; i++)
        {
            RankingScore[i] = PlayerPrefs.GetInt(ranking[i], 0);
        }

        //�Ăяo���������L���O�Ɗl�������X�R�A���r������ւ���
        for (int i = 0; i < 5; i++)
        {
            if(Score >= RankingScore[i])
            {
                var change = RankingScore[i];
                RankingScore[i] = Score;
                Score = change;
            }
        }

        //����ւ����l��ۑ�
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt(ranking[i], RankingScore[i]);
            PlayerPrefs.Save();

            ScoreText[i].text = RankingScore[i].ToString()+"�b"; 
        }

        PlayerPrefs.SetInt("TEST", 0);//�l�������X�R�A�̏�����
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
