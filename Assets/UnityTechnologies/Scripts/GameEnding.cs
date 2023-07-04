using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YooAsset;

public class GameEnding : MonoBehaviour
{
    // Start is called before the first frame update
    public float fadeDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public AudioSource caughtAudio;
    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    float m_Timer;
    bool m_HasAudioPlayed;
    public float displayImageDuration = 1f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;
        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                var package = YooAssets.GetPackage("DefaultPackage");
                var sceneMode = UnityEngine.SceneManagement.LoadSceneMode.Single;
                bool activateOnLoad = true;
                YooAssets.LoadSceneAsync("MainScene", sceneMode, activateOnLoad);
            }
            else
            {
                Application.Quit();
            }
        }
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
    }
    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }
}
