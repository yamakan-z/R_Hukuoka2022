using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeIn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �t�F�[�h�C���I����̏���
    public void EndFadeInAnimation()
    {
        Destroy(this.gameObject);
    }
}
