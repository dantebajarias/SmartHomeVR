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


    void Start()
    {
        // 初始化频道显示
        UpdateChannel();

        // 添加按钮点击事件监听器
        nextButton.onClick.AddListener(NextChannel);
        previousButton.onClick.AddListener(PreviousChannel);
    }

    // 切换到下一个频道
    void NextChannel()
    {
        currentChannel = (currentChannel + 1) % channelSprites.Length;
        UpdateChannel();
    }

    // 切换到上一个频道
    void PreviousChannel()
    {
        currentChannel = (currentChannel - 1 + channelSprites.Length) % channelSprites.Length;
        UpdateChannel();
    }

    // 更新频道图片显示
    void UpdateChannel()
    {
        channelImage.sprite = channelSprites[currentChannel];
        
        // 切换音频
        if (audioSource != null && channelAudioClips.Length > currentChannel)
        {
            audioSource.clip = channelAudioClips[currentChannel];
            audioSource.Play();
        }
    }
}

