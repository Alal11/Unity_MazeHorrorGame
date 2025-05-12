using UnityEngine;

public class GhostChaseTrigger : MonoBehaviour
{
    public GameObject wallToToggle;       // 생성/삭제할 벽
    public GameObject ghost;              // 귀신
    public Transform player;              // 플레이어
    private bool isChasing = false;

    public void StartChase()
    {
        if (!isChasing)
        {
            isChasing = true;

            if (wallToToggle != null)
                wallToToggle.SetActive(true);

            Debug.Log("StartChase() 호출됨 - 추격 시작");
        }
    }

    private void Update()
    {
        if (isChasing && ghost != null && player != null)
        {
            // 위치 이동
            ghost.transform.position = Vector3.MoveTowards(
                ghost.transform.position,
                player.position,
                3f * Time.deltaTime
            );

            // 플레이어 방향으로 회전
            Vector3 direction = player.position - ghost.transform.position;
            direction.y = 0; // 수직 회전 방지 (Y축 고정)
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                ghost.transform.rotation = Quaternion.Slerp(
                    ghost.transform.rotation,
                    targetRotation,
                    5f * Time.deltaTime // 회전 속도 조절
                );
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isChasing && other.CompareTag("Player"))
        {
            if (wallToToggle != null)
                wallToToggle.SetActive(false);

            if (ghost != null)
                ghost.SetActive(false);

            Debug.Log("괴물이 플레이어에 닿음 - 괴물과 벽 제거됨");
        }
    }
}
