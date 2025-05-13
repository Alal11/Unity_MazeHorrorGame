using UnityEngine;

public class CreepTriggerScript : MonoBehaviour
{
    public GameObject monster;       // Creep3
    public Transform player;         // PlayerCapsule
    public float moveSpeed = 3f;     // 이동 속도

    private bool isChasing = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = true;
            Debug.Log("Creep 추격 시작!");
        }
    }

    private void Update()
    {
        if (isChasing && monster != null && player != null)
        {
            monster.transform.position = Vector3.MoveTowards(
                monster.transform.position,
                player.position,
                moveSpeed * Time.deltaTime
            );

            // 플레이어 방향을 바라보도록 회전
            Vector3 direction = (player.position - monster.transform.position).normalized;
            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                monster.transform.rotation = Quaternion.Slerp(monster.transform.rotation, lookRotation, Time.deltaTime * 5f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isChasing && collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Creep 닿음 - 소멸");
            monster.SetActive(false);
        }
    }
}
