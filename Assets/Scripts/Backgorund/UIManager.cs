using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pausePanel;
    bool oyunudurdur = false;
    public GameObject gameover;
    public static UIManager instance;
    public GameObject finish;
   

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DurumDegistir();
        }
    }
    void DurumDegistir()
    {
        oyunudurdur = !oyunudurdur;
        if (oyunudurdur)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void PaneliAc()
    {
        if (!oyunudurdur)
        {
            SoundManager.instance.MouseClick();
            DurumDegistir();
        }
    }
    public void PaneliKapat()
    {
        if (oyunudurdur)
        {
            DurumDegistir();
        }
    }
    public void GameOverPanel()
    {
        gameover.SetActive(true);
        Time.timeScale = 0f;
        SoundManager.instance.PlayerSound();
}

    public void FinishPanel()
    {
        if (finish!=null)
        {
            finish.SetActive(true);
            Time.timeScale = 0f;
            SoundManager.instance.WinSound();
        }
        
    }

    public void TekrarOyna()
    {
        SoundManager.instance.MouseClick();
        SceneManager.LoadScene("Level_1");
        Time.timeScale = 1f;
    }
    public void AnaMenü()
    {
        SoundManager.instance.MouseClick();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MaýnMenü");
    }

}
