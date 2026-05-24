using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] int hasarmik = 10;
    [SerializeField] GameObject efect;
  
    private void Update()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime); 
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Meteor"))
        {
            Instantiate(efect, transform.position, Quaternion.identity);
            SoundManager.instance.MeteroSound();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth dusmanscripti = other.gameObject.GetComponent<EnemyHealth>();
           
            if (dusmanscripti != null)
            {
                dusmanscripti.AlýnanHasar(hasarmik);
            }
            
            Destroy(gameObject);
        }
    }

}
