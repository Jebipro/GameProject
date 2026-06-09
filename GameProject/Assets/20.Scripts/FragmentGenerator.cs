using UnityEngine;

public class FragmentGenerator : MonoBehaviour
{
    public GameObject[] fragmentPrefabs; 
    float span = 1.0f;
    float delta = 0;

    void Update()
    {
        delta += Time.deltaTime;
        if(delta > span)
        {
            delta = 0;
            // 배열 크기 안에서 무작위 인덱스 뽑기 (0, 1, 2 중 하나)
            int randomIndex = Random.Range(0, fragmentPrefabs.Length);
            GameObject go = Instantiate(fragmentPrefabs[randomIndex]);
            
            float px = Random.Range(-8f, 8f);
            go.transform.position = new Vector3(px, 6f, 0);
        }
    }
}