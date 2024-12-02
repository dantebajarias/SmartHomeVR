using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Pslight : MonoBehaviour
{
    public Toggle ps3Toggle; // 拖入场景中的 Toggle
    public Light ps3AreaLight; // 拖入场景中的 Area Light

    void Start()
    {
        // 添加 Toggle 的事件监听器
        ps3Toggle.onValueChanged.AddListener(PS3LightColor);
    }

    void PS3LightColor(bool isOn)
    {
        // 根据 Toggle 状态切换灯光颜色
        if (isOn)
        {
            ps3AreaLight.color = Color.blue; // 切换为蓝色
        }
        else
        {
            ps3AreaLight.color = Color.red; // 切换为红色
        }
    }
}