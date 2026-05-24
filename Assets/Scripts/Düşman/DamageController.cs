using UnityEngine;

public class DamageController : MonoBehaviour
{
    public int hasarmiktarý = 2;
    private void OnCollisionEnter2D(Collision2D other)
    {
          if(other.gameObject.CompareTag("Player"))
        {
            PlayerHealth.instance.HasarAL(hasarmiktarý);

            Debug.Log("çarpýþma");
            Destroy(gameObject);
        }
    }
}
