using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //「SCORE」というキーで保存されているInt値を読み込み
        float resultScore = PlayerPrefs.GetFloat("TEST");
        Debug.Log("保存されている点数：" + resultScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
