using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScript : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;

    public void HowTo()
    {
        StartCoroutine(ChangeScreen(2));
    }
    public void Play()
    {
        StartCoroutine(ChangeScreen(1));
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        StartCoroutine(ChangeScreen(0));
    }
    public void Close()
    {
        Application.Quit();
    }
    IEnumerator ChangeScreen(int levelIndex)
    {
        transition.SetTrigger("CircleTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
