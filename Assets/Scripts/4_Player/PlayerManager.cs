using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Text _text;
    [SerializeField] Button _button;

    void Awake()
    {
        _button.onClick.AddListener(Submit);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Submit()
    {
        _text.text = PhotonNetwork.LocalPlayer.ActorNumber.ToString();
    }
}
