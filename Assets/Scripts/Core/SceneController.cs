using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private RectTransform currentPanel;
    [SerializeField] private List<RectTransform> panels;

    [SerializeField] private Vector3 endValue;
    [SerializeField] private float doDurationTime;
    [SerializeField] private AudioClip startSpeech;
    [SerializeField] private AudioClip emotionPanelSpeech;
    [SerializeField] private GameObject animator;

    private void Start()
    {
        StartCoroutine(LoadingSquance());
    }

    private IEnumerator LoadingSquance()
    {
        yield return new WaitForSeconds(5f);
        ChangeScene(panels[1]);
        currentPanel.DOMoveY(Screen.height / 2, 5f);
        yield return new WaitForSeconds(1f);
        SoundController.Instance.PlaySound(startSpeech);
    }

    public void ChangeScene(RectTransform targetPanel)
    {
        currentPanel.gameObject.SetActive(false);
        animator.SetActive(false);
        currentPanel = targetPanel;
        currentPanel.gameObject.SetActive(true);    
    }

    public void OpenEmotionPanel()
    {
        ChangeScene(panels[2]);
        SoundController.Instance.PlaySound(emotionPanelSpeech);
    }
}
