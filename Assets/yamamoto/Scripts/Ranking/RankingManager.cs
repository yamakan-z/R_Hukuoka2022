using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    public GameObject Ranking;//�����L���O��ʂ�����

    // Start is called before the first frame update
    void Start()
    {
        Ranking.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
