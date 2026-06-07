using UnityEngine;
using UnityEngine.UI;
using System.Collections; // 코루틴 사용을 위해 필요

public class GameDirector : MonoBehaviour
{
    public Image hpGauge;
    public Image blindPanel; // 화면 전체를 가릴 반투명 검은색 UI 이미지
    public PlayerController player; // 스턴을 걸기 위해 플레이어 스크립트 연결
    public GameObject gameOverText;

    public void HitFragment(int type)
    {
        if (type == 0) // 빨간색: 실명
        {
            StartCoroutine(BlindRoutine());
        }
        else if (type == 1) // 파란색: 스턴
        {
            StartCoroutine(StunRoutine());
        }
        else if (type == 2) // 보라색: 언데드 (대체)
        {
            // 현재 게임엔 힐이 없으므로, 맞으면 일반 데미지의 2~3배를 깎는 식으로 끔살 구현
            hpGauge.fillAmount -= 0.3f; 
        }
        else 
        {
            hpGauge.fillAmount -= 0.1f;
        }

        if (hpGauge.fillAmount <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverText.SetActive(true); // 숨겨뒀던 게임오버 글자 띄우기
        Time.timeScale = 0f; // 게임 시간 정지 (파편이 더 안 떨어지고 플레이어도 멈춤)

        player.isStunned = true;
    }

    IEnumerator BlindRoutine()
    {
        blindPanel.gameObject.SetActive(true); // 검은 화면 활성화
        yield return new WaitForSeconds(1.5f); // 1.5초 대기
        blindPanel.gameObject.SetActive(false); // 검은 화면 비활성화
    }

    IEnumerator StunRoutine()
    {
        player.isStunned = true; // 플레이어 스턴 걸기
        yield return new WaitForSeconds(1.0f); // 1초 대기
        player.isStunned = false; // 플레이어 스턴 해제
    }
}