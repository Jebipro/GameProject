using UnityEngine;

public class FragmentController : MonoBehaviour
{
    GameObject player;
    GameObject director;

    float minDistance = 1.1f;
    public float dropSpeed = 0.1f;
    
    // 0: 빨간색(실명), 1: 파란색(스턴), 2: 보라색(언데드)
    public int fragmentType; 

    private void Start()
    {
        player = GameObject.Find("player");
        director = GameObject.Find("GameDirector");
    }

    void Update()
    {
        transform.Translate(0, -dropSpeed, 0);

        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }

        Vector2 p1 = transform.position;
        Vector2 p2 = player.transform.position;
        float distance = (p1 - p2).magnitude;
        
        if(distance < minDistance)
        {
            // GameDirector에게 어떤 파편에 맞았는지 종류를 넘겨줌
            director.GetComponent<GameDirector>().HitFragment(fragmentType);
            Destroy(gameObject);
        }
    }
}