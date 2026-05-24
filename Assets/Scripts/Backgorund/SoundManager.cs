using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField]  AudioSource mouseclik;
    [SerializeField] AudioSource enemydealth;
    [SerializeField] AudioSource playerdealth;
    [SerializeField] AudioSource meteor;
    [SerializeField] AudioSource win;
    private void Awake()
    {
        instance = this;
    }
    public void MouseClick()
    {
        mouseclik.Play();
    }
    public void EnmeySound()
    {
        enemydealth.Play();
    }
    public void PlayerSound()
    {
        playerdealth.Play();
    }
    public void MeteroSound()
    {
        meteor.Play();
    }
    public void WinSound()
    {
        win.Play();
    }
}
