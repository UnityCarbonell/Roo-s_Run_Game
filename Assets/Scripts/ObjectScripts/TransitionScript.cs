using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScript : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;

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
        Debug.Log("The game is closing");
        Application.Quit();
    }
    IEnumerator ChangeScreen(int levelIndex)
    {
        transition.SetTrigger("CircleTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
