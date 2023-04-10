#if UNITY_EDITOR
using UnityEngine;

public class MemoPad : MonoBehaviour
{
    [TextArea(500, 500)]
    [SerializeField] string memo;
}
#endif