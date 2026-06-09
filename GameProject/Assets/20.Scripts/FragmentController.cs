using UnityEngine;

public class FragmentController : MonoBehaviour
{
    GameObject player;
    GameObject director;

    float minDistance = 1.1f;
    public float dropSpeed = 6f;
    
    // 0: 빨간색(실명), 1: 파란색(스턴), 2: 보라색(데미지)
    public int fragmentType; 

    private void Start()
    {
        player = GameObject.Find("player");
        director = GameObject.Find("GameDirector");
    }

    void Update()
    {
        transform.Translate(0, -dropSpeed * Time.deltaTime, 0);

        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }

        Vector2 p1 = transform.position;
        Vector2 p2 = player.transform.position;
        float distance = (p1 - p2).magnitude;
        
        if(distance < minDistance)
        {
            director.GetComponent<GameDirector>().HitFragment(fragmentType);
            Destroy(gameObject);
        }
    }
}