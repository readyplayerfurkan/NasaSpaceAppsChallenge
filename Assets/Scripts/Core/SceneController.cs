using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private RectTransform currentPanel;
    [SerializeField] private List<RectTransform> panels;

    private void Start()
    {
        StartCoroutine(LoadingSquance());
    }

    private IEnumerator LoadingSquance()
    {
        yield return new WaitForSeconds(5f);
        currentPanel.DOMoveY(1000, 5f);
        yield return new WaitForSeconds(5f);
        ChangeScene(panels[1]);
    }

    public void ChangeScene(RectTransform targetPanel)
    {
        currentPanel.gameObject.SetActive(false);
        currentPanel = targetPanel;
        currentPanel.gameObject.SetActive(true);
    }
}
