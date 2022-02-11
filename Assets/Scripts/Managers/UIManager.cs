using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Animator deadUI;
    public Animator pauseUI;
    public Animator gameplayUI;
    public Animator bonusUI;

    public GameObject pauseUIObj;
    public GameObject pauseBtnObj;
    void OnEnable()
    {
        GameEvents.Died += DeadScreen;
        GameEvents.gc += PlusFifty;
    }
    void OnDisable()
    {
        GameEvents.Died -= DeadScreen;
        GameEvents.gc -= PlusFifty;
    }

    public void DeadScreen()
    {
        deadUI.SetTrigger("Show");
        gameplayUI.SetTrigger("GameOver");
    }

    public void Paused()
    {
        Debug.Log("The game is now paused");
        pauseUIObj.SetActive(true);
        pauseBtnObj.SetActive(false);
        Time.timeScale = 0f;
        //pauseUI.SetBool("Pause", true);
    }

    public void PausedOff()
    {
        Debug.Log("The game is now playing");
        pauseBtnObj.SetActive(true);
        pauseUIObj.SetActive(false);
        Time.timeScale = 1f;
        //pauseUI.SetBool("Pause", false);
    }

    private void PlusFifty()
    {
        bonusUI.SetTrigger("PlusFifty");
    }
}