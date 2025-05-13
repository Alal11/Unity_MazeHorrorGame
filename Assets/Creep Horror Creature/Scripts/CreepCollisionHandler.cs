using UnityEngine;

public class CreepCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Creep이 플레이어에게 닿음! 제거됨");
            Destroy(gameObject); // 괴물 제거
        }
    }
}
