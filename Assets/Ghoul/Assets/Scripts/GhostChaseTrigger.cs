using UnityEngine;

public class GhostChaseTrigger : MonoBehaviour
{
    public GameObject wallToToggle;       // 생성/삭제할 벽
    public GameObject ghost;              // 귀신
    public Transform player;              // 플레이어
    public float chaseDistance = 10f;     // 감지 거리

    private bool isChasing = false;

    public void StartChase()  // ← 이 함수 추가됨
    {
        if (!isChasing)
        {
            isChasing = true;
            wallToToggle.SetActive(true);
        }
    }

    private void Update()
    {
        if (isChasing)
        {
            ghost.transform.position = Vector3.MoveTowards(
                ghost.transform.position,
                player.position,
                3f * Time.deltaTime
            );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isChasing && other.CompareTag("Player"))
        {
            wallToToggle.SetActive(false);
            ghost.SetActive(false);
        }
    }
}
