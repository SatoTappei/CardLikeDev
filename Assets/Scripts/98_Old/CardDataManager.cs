using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カードのデータを管理する、各カードはこのクラスからSOを取得する
/// </summary>
public class CardDataManager : MonoBehaviour
{
    [SerializeField] CardDataSO[] _sos;
    /// <summary>タグをキーにSOを取得するための辞書型</summary>
    static Dictionary<CardTag, CardDataSO> _dic = new Dictionary<CardTag, CardDataSO>();

    void Awake()
    {
        foreach (CardDataSO so in _sos)
            _dic.Add(so.Tag, so);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /// <summary>タグからSOを取得する</summary>
    public static CardDataSO GetSO(CardTag tag) => _dic[tag];
}
