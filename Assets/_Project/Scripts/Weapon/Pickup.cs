using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Gun _gunPrefab;
    [SerializeField] private AudioClip _sfx;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_gunPrefab.IsEquipped)
        {
            AudioManager.Instance.PlaySFX(_sfx);

            SpawnManager.Instance.StartWave();

            Gun gun = GetComponent<Gun>();
            gun = Instantiate(_gunPrefab);
            gun.SetPlayer(collision.transform);
            gun.transform.position = collision.transform.position;
            BulletPool pool = FindObjectOfType<BulletPool>();
            gun.SetBulletPool(pool);

            gun.Equip();
            Destroy(gameObject, _sfx.length);
        }
    }
}


