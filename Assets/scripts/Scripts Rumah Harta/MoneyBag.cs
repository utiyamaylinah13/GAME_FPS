using UnityEngine;

public class MoneyBag : MonoBehaviour
{
    public int moneyValue = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddMoney(moneyValue);

            Destroy(gameObject);
        }
    }
}