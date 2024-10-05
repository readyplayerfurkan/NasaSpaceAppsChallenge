using DG.Tweening;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private RectTransform panel;

    void Start()
    {
        panel.DOMoveX(100, 5f);
    }
}
