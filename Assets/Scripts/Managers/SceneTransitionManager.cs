using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SceneTransitionManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clickSound;

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
        Thread.Sleep(100);
    }

    public void StartNewGame()
    {
        PlayClickSound();
        SceneManager.LoadScene(1);
    }

    public void ShowRecords()
    {
        PlayClickSound();
        SceneManager.LoadScene(2);
    }

    public void ShowCredits()
    {
        PlayClickSound();
        SceneManager.LoadScene(3);
    }

    public void ReturnToMenu()
    {
        PlayClickSound();
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        PlayClickSound();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
