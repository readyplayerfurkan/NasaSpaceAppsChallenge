using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] private RectTransform currentPanel;
    [SerializeField] private List<RectTransform> panels;
    [SerializeField] private Vector3 endValue;
    [SerializeField] private float doDurationTime;

    [Header("Loading Components")]
    [SerializeField] private TextMeshProUGUI waitMessage;
    [SerializeField] private TextMeshProUGUI loadingMessage;
    [SerializeField] private Image loadingImage;

    private void Start()
    {
        StartCoroutine(LoadingSquance());
    }

    private IEnumerator LoadingSquance()
    {
        //while(true)
        //{
        //    yield return new WaitForSeconds(0.2f);
        //    // waitMessage.color.a -= 0.2f;
        //}

        yield return new WaitForSeconds(5f);
        ChangeScene(panels[1]);

    }

    public void ChangeScene(RectTransform targetPanel)
    {
        currentPanel.gameObject.SetActive(false);
        currentPanel = targetPanel;
        currentPanel.gameObject.SetActive(true);
        currentPanel.DOMoveY(435, 5f);
    }
}
