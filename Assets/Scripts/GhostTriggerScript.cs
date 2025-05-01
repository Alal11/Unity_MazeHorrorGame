using UnityEngine;

public class GhostTriggerScript : MonoBehaviour
{
    public GhostChaseTrigger ghostChaseScript; // 괴물에 붙은 스크립트 참조

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && ghostChaseScript != null)
        {
            ghostChaseScript.StartChase();
        }

        Debug.Log("트리거에 닿은 오브젝트: " + other.name); // 디버그 출력

        if (other.CompareTag("Player") && ghostChaseScript != null)
        {
            ghostChaseScript.StartChase();
            Debug.Log("괴물 추격 시작!");
        }
    }
}
