//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;

//public class FadeManager : MonoBehaviour
//{
//    [SerializeField]
//    private GameObject panelFade; //�t�F�[�h�p�l��
//    [SerializeField, Range(0, 1)]
//    private float alpha; //�A���t�@�l�A0�`1��Range��ݒ�
//    private Image panel_fadeImage; //�t�F�[�h�p�l����Image
//    private bool fadeout, fadein; //�t�F�[�h�p�l����Image
//    private int MainScene;

//    private void Start()
//    {
//        panel_fadeImage = panelFade.GetComponent<Image>();
//        PanelEnabled();

//        FadeIn();
//    }

//    private void Update()
//    {
//        if (fadein)
//            FadeInOperation();

//        if (fadeout)
//            FadeOutOperation();
//    }

//    //�t�F�[�h�C���Ăяo��
//    private void FadeIn()
//    {
//        if (alpha != 1)
//            alpha = 1f;

//        fadein = true;
//    }

//    //�t�F�[�h�A�E�g�Ăяo��
//    private void FadeOut()
//    {
//        if (alpha != 0)
//            alpha = 0f;

//        fadeout = true;
//    }

//    //�t�F�[�h�C������
//    private void FadeInOperation()
//    {
//        alpha -= 0.01f;

//        var tempColor = panel_fadeImage.color;

//        tempColor.a = alpha;
//        panel_fadeImage.color = tempColor;

//        PanelEnabled();

//        if (alpha <= 0)
//            fadein = false;
//    }

//    //�t�F�[�h�A�E�g����ƃV�[���J��
//    private void FadeOutOperation()
//    {
//        alpha += 0.01f;

//        var tempColor = panel_fadeImage.color;

//        tempColor.a = alpha;
//        panel_fadeImage.color = tempColor;

//        PanelEnabled();

//        if(alpha>=1)
//        {
//            fadeout = false;
//            SceneManager.LoadScene("Fade" + );
//        }
//    }

//    //�t�F�[�h�p�l���̕\����ԊǗ�
//    private void PanelEnabled()
//    {
//        if (alpha <= 0)
//            panelFade.SetActive(false);

//        else
//            panelFade.SetActive(true);
//    }

//    //�V�[���J�ڎ��̃{�^������
//    public void SceneMove(int num)
//    {
//        MainScene = num;
//        FadeOut();
//    }
//}
