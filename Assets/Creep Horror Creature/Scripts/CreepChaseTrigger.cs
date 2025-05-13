using UnityEngine;

public class CreepChaseTrigger : MonoBehaviour
{
    public GameObject wallToToggle;
    public GameObject creep;
    public Transform player;
    public float moveSpeed = 3f;

    private bool isChasing = false;

    public void StartChase()
    {
        if (!isChasing)
        {
            isChasing = true;
            if (wallToToggle != null)
                wallToToggle.SetActive(true);
        }
    }

    private void Update()
    {
        if (isChasing && creep != null && player != null)
        {
            creep.transform.position = Vector3.MoveTowards(
                creep.transform.position,
                player.position,
                moveSpeed * Time.deltaTime
            );

            // 방향 회전
            Vector3 direction = (player.position - creep.transform.position).normalized;
            direction.y = 0f;
            if (direction.magnitude > 0)
                creep.transform.forward = direction;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isChasing && other.CompareTag("Player"))
        {
            if (wallToToggle != null)
                wallToToggle.SetActive(false);
            creep.SetActive(false);
        }
    }
}
