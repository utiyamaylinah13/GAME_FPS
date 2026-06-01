using UnityEngine;

public class MoneyBag : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Uang berhasil diambil!");

            Destroy(gameObject);
        }
    }
}