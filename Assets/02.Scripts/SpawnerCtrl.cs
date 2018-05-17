using UnityEngine;
using System.Collections;

public class SpawnerCtrl : MonoBehaviour 
{
    public GameObject EnemyPrefab;
    public float fZenTime = 0.5f;

	// Use this for initialization
	void Start () 
    {
        StartCoroutine("CreateMonster");
	}

    IEnumerator CreateMonster()
    {
        while(true)
        {
            GameObject EnemyObj = Instantiate(EnemyPrefab);
            // 배치될 새로운 위치
            Vector3 vPos = new Vector3(
                transform.position.x + Random.Range(-4.0f, 4.0f),
                transform.position.y,
                transform.position.z);

            // 새로운 위치를 적용
            EnemyObj.transform.position = vPos;

            // fZenTime시간 만큼 대기
            yield return new WaitForSeconds(fZenTime);
        }
    }


}
