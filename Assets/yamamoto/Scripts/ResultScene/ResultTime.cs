using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResultTime : MonoBehaviour
{
    [SerializeField, Header("�������ԃe�L�X�g")]
    private Text scoretext;

    [SerializeField]
    private int score;//�����ɕۑ������������Ԃ�����


    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("TEST", 0);
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "<color=#FFFFFF>���Ȃ���</color>" + score.ToString()+ "�b<color=#FFFFFF>�����c�����I�I</color>";
        //�����ŕb���𔽉f�i�J���[�R�[�h�w��ňꕔ�̕����̐F�ύX�j

        //scoretext.text = "00:"+score.ToString();//�����ŕb���𔽉f
    }
}
