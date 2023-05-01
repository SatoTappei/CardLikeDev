using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 再生する音を指定するための列挙型
/// </summary>
public enum AudioType
{
    SE_Cancel
}

/// <summary>
/// インスペクターから割り当てるための音のデータ
/// </summary>
[System.Serializable]
public class AudioData
{
    [SerializeField] AudioType _key;
    [SerializeField] AudioClip _clip;
    [SerializeField] float _volume;

    public AudioType Key => _key;
    public AudioClip Clip => _clip;
    public float Volume => _volume;
}

/// <summary>
/// 音の再生を行うクラス
/// </summary>
public class AudioModule
{
    /// <summary>掃除に再生できる音の数</summary>
    static readonly int PlayAtSame = 10;
    /// <summary>連続で再生できる間隔</summary>
    static readonly float Interval = 0.05f;

    AudioSource[] _audioSources = new AudioSource[PlayAtSame];
    Dictionary<AudioType, AudioData> _audioDict = new();

    float _lastTime;

    public AudioModule(GameObject gameObject, AudioData[] audioDatas)
    {
        for(int i = 0; i < _audioSources.Length; i++)
        {
            _audioSources[i] = gameObject.AddComponent<AudioSource>();
        }

        foreach(AudioData data in audioDatas)
        {
            _audioDict.Add(data.Key, data);
        }
    }

    public void PlaySE(AudioType type)
    {
        if (IsInterval()) return;

        AudioData data = GetData(type);
        AudioSource source = GetSourceSE();
        if (data == null || source == null) return;

        source.clip = data.Clip;
        source.volume = data.Volume;
        source.Play();
    }

    public void PlayBGM()
    {
        // 作ってない
    }

    bool IsInterval()
    {
        if (Time.realtimeSinceStartup - _lastTime > Interval)
        {
            _lastTime = Time.realtimeSinceStartup;
            return false;
        }
        else
        {
            return true;
        }
    }

    AudioSource GetSourceSE()
    {
        // 一番後ろのAudioSourceはBGM再生用なので取っておく
        for(int i = 0; i < _audioSources.Length - 1; i++)
        {
            if (!_audioSources[i].isPlaying) return _audioSources[i];
        }

        Debug.LogWarning("AudioSourceが足らない");
        return null;
    }

    AudioData GetData(AudioType type)
    {
        if (_audioDict.TryGetValue(type, out AudioData data))
        {
            return data;
        }

        throw new KeyNotFoundException($"音が登録されていない: {type}");
    }
}
