using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeAnimRe : MonoBehaviour
{
    public GameObject Panelfade; //�t�F�[�h�p�l���̎擾

    Image fadealpha; //�t�F�[�h�p�l���̃C���[�W�擾�ϐ�

    private float alpha; //�p�l����alpha�l�擾�ϐ�

    private bool fadeout; //�t�F�[�h�A�E�g�̃t���O�ϐ�
    private bool fadein; //�t�F�[�h�C���̃t���O�ϐ�

    private void Start()
    {
        fadealpha = Panelfade.GetComponent<Image>(); //�p�l���̃C���[�W�擾
        alpha = fadealpha.color.a; //�p�l����alpha�l���擾
        fadein = true; //�V�[���ǂݍ��ݎ��Ƀt�F�[�h�C��������
    }

    private void Update()
    {
        if(fadein==true)
        {
            FadeIn();
        }

        if(fadeout==true)
        {
            FadeOut();
        }
    }

    void FadeIn()
    {
        alpha -= 0.1f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if(alpha<=0)
        {
            fadein = false;
            Panelfade.SetActive(false);
        }
    }

    void FadeOut()
    {
        alpha += 0.1f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if(alpha>=1)
        {
            fadeout = false;
            SceneManager.LoadScene("MainScene");
        }
    }

    public void SceneMove()
    {
        fadeout = true;
        Panelfade.SetActive(true);
    }
}
