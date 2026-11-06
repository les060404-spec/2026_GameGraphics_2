using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{
    public Transform target;     // 이동할 목적지 위치
    public GameObject prompt;   // 문 앞에 뜨는 말풍선 UI

    private Transform player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            prompt.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
            prompt.SetActive(false);
        }
    }

    void Update()
    {
        // 플레이어가 범위 안에 있고 E 키를 눌렀을 때 순간이동
        if (player != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            player.position = target.position;
        }
    }
}