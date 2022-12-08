using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{

    [SerializeField, Header("警告マーク")]
    private Renderer warning;

    [SerializeField, Header("点滅の速さ")]
    private float level;

    private float w_time;//点滅用のタイマー

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        w_time += Time.deltaTime;

        // 周期levelで繰り返す値の取得
        // 0～levelの範囲の値が得られる
        var repeatValue = Mathf.Repeat(w_time, level);

        // 内部時刻w_timeにおける明滅状態を反映
        warning.enabled = repeatValue >= level * 0.5f;
    }
}
