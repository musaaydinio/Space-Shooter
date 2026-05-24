using UnityEngine;
using UnityEngine.SceneManagement;

public class AnaMenu : MonoBehaviour
{
    public void OyunaBasla()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void OyundanÇýk()
    {
        Application.Quit();
    }
}
