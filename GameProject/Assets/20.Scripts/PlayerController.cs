using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f;
    public bool isStunned = false;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // PC용 테스트 코드 활성화
    void Update()
    {
        if (isStunned) return; // 스턴 상태면 아래 코드를 무시하고 바로 종료

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }

    // 모바일용 코드
    public void LButtonDown()
    {
        if (!isStunned) transform.Translate(-speed, 0, 0);
    }
    
    public void RButtonDown()
    {
        if (!isStunned) transform.Translate(speed, 0, 0);
    }
}