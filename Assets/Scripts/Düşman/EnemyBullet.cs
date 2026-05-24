using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float mermihýzý = 5f;
    [SerializeField] int hasarMiktarý = 5;

    private void Update()
    {
        transform.Translate(Vector3.down * mermihýzý * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth.instance.HasarAL(hasarMiktarý);
        }
    }

}
