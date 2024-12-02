using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.UI;

public class ChannelController : MonoBehaviour
{
    public Image channelImage; // 用于显示频道图片的 Image 对象
    public Sprite[] channelSprites; // 存储所有频道的图片
    private int currentChannel = 0; // 当前频道索引

    public AudioSource audioSource;
    public AudioClip[] channelAudioClips;

    public Button nextButton; // 上按钮
    public Button previousButton; // 下按钮

    public Toggle powerToggle; // 控制电视开关的 Toggle
    private bool isTVOn = false; // 表示电视的开关状态

    void Start()
    {
        currentChannel = 0; // 确保从第一个频道开始
        // channelImage.sprite = channelSprites[currentChannel];
        // 初始化频道显示
        channelImage.enabled = false;
        UpdateChannel();

        // 添加按钮点击事件监听器
        nextButton.onClick.AddListener(NextChannel);
        previousButton.onClick.AddListener(PreviousChannel);

        // 添加 Toggle 状态变化监听器
        powerToggle.onValueChanged.AddListener(SetTVState);
    }


    // 设置电视的开关状态
    void SetTVState(bool isOn)
    {
        isTVOn = isOn;

        // 根据电视状态控制内容显示
        if (isTVOn)
        {
            channelImage.enabled = true; // 显示频道图片
            UpdateChannel();
            // audioSource.Play(); // 播放当前频道音频
        }
        else
        {
            channelImage.enabled = false; // 隐藏频道图片
            audioSource.Stop(); // 停止播放音频
        }
    }


    // 切换到下一个频道
    void NextChannel()
    {
        if (!isTVOn) return; // 如果电视是关的，不切换频道

        currentChannel = (currentChannel + 1) % channelSprites.Length;
        UpdateChannel();
    }

    // 切换到上一个频道
    void PreviousChannel()
    {
        if (!isTVOn) return; // 如果电视是关的，不切换频道

        currentChannel = (currentChannel - 1 + channelSprites.Length) % channelSprites.Length;
        UpdateChannel();
    }

    // 更新频道图片显示
    void UpdateChannel()
    {
        if (isTVOn) {
            channelImage.sprite = channelSprites[currentChannel];
            
            // 切换音频
            if (audioSource != null && channelAudioClips.Length > currentChannel)
            {
                audioSource.clip = channelAudioClips[currentChannel];
                audioSource.Play();
            }
        }
    }
}

