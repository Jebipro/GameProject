using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public Image hpGauge;
    public Image blindPanel;
    public PlayerController player;
    public GameObject gameOverText;

    private bool isGameOver = false;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void HitFragment(int type)
    {
        if (isGameOver) return;

        if (type == 0) // 빨간색: 실명
        {
            StartCoroutine(BlindRoutine());
        }
        else if (type == 1) // 파란색: 스턴
        {
            StartCoroutine(StunRoutine());
        }
        else if (type == 2) // 보라색: 데미지
        {
            hpGauge.fillAmount -= 0.3f; 
        }
        else 
        {
            // 오류 방지
            hpGauge.fillAmount -= 0.1f;
        }

        if (hpGauge.fillAmount <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        gameOverText.SetActive(true);

        Time.timeScale = 0f;
        player.isStunned = true;
    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator BlindRoutine()
    {
        blindPanel.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        blindPanel.gameObject.SetActive(false);
    }

    IEnumerator StunRoutine()
    {
        player.isStunned = true;
        yield return new WaitForSeconds(1.0f);
        player.isStunned = false;
    }
}