using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using UniRx;

/// <summary>
/// プレイヤーの入力に応じてカードを場に出す
/// </summary>
public class PlayerCommand : MonoBehaviour
{
    [SerializeField] Transform _hand;
    [SerializeField] Transform _field;
    [SerializeField] Transform _garbageCan;

    // TODO:ここ以外でも使うならば便利クラスを作って移す
    /// <summary>ゲーム開始時の手札の枚数</summary>
    readonly int DefaultHand = 10;

    /// <summary>
    /// ソート用の辞書型、起動時にヒエラルキーに並んでいた順にソートさせる
    /// </summary>
    Dictionary<string, int> _sortDic = new Dictionary<string, int>();

    /// <summary>ソート時に使う一時保存用のリスト</summary>
    List<Transform> _tempList = new List<Transform>();

    void Start()
    {

    }

    void Update()
    {
        
    }

    /// <summary>ソートできるようにカードを辞書型に追加する</summary>
    public void AddSortDic(GameObject card)
    {
        _sortDic.Add(card.name, card.transform.GetSiblingIndex());
    }

    /// <summary>カードを場に出す</summary>
    public void ToField(Transform card)
    {
        // 渡されたカードを場に移動させるアニメーションを行う
        card.DOMove(_field.position, 0.15f);
        // 渡されたカードを場のカードと交換する
        Transform prev = ChangeCard(card);
        // 戻ってきたカードは手札に加える
        if (prev != null) prev.SetParent(_hand);
        // ソートする
        SortHand();
    }

    /// <summary>場のカードを交換する</summary>
    Transform ChangeCard(Transform card)
    {
        if (_field.transform.childCount == 0)
        {
            // 場にカードがない場合は、そのカードを場にセットしてnullを返す
            card?.SetParent(_field);
            return null;
        }
        else
        {
            // 場にカードがある場合は、交換して前のカードを返す
            Transform prev = _field.transform.GetChild(0);
            card?.SetParent(_field);
            return prev;
        }
    }

    /// <summary>手札をソート(ヒエラルキーの順番を弄る)する</summary>
    public void SortHand()
    {
        // SetSiblingIndex()は呼んだ時点でソートされるのでループ中に順番が変わってしまう
        // なので一度リストに格納してそれをソートし、反映させていく。
        // SetSiblingIndexの引数が固定なのは要素数以上を指定すると"一番下"に配置されるため
        _tempList.Clear();
        foreach (Transform trans in _hand)
            _tempList.Add(trans);

        foreach (Transform trans in _tempList.OrderBy(t => _sortDic[t.gameObject.name]).ToList())
            trans.SetSiblingIndex(DefaultHand + 1);
    }

    /// <summary>
    /// 場のカードをゴミ箱に移すことで
    /// 決定ボタンを再度表示できるようにする
    /// </summary>
    public void CleanField()
    {
        Transform prev = ChangeCard(null);
        prev.SetParent(_garbageCan);
    }
}
