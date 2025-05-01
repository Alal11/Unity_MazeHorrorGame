using UnityEngine;
using TMPro; // TMP 사용하는 경우

public class ExitTriggerScript : MonoBehaviour
{
    public GameObject successUI;  // 🎯 Canvas Drag & Drop

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("🎉 탈출 성공!");
            if (successUI != null)
            {
                successUI.SetActive(true);
            }
        }
    }
}
