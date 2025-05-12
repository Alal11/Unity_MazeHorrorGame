using UnityEngine;

public class GhostTriggerScript : MonoBehaviour
{
    public GhostChaseTrigger ghostChaseScript; // 괴물에 붙은 스크립트 참조

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("트리거에 닿은 오브젝트: " + other.name);

        if (other.CompareTag("Player") && ghostChaseScript != null)
        {
            ghostChaseScript.StartChase();
            Debug.Log("괴물 추격 시작!");
        }
    }
}