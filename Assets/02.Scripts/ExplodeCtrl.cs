using UnityEngine;
using System.Collections;

public class ExplodeCtrl : MonoBehaviour 
{
    public float lifeTime = 1.0f;   // 객체가 살아있을 시간

    void OnEnable()
    {
        // 1초뒤에 Die라는 함수를 호출해라.
        Invoke("Die", lifeTime);
    }

    void Die()
    {
        Destroy(gameObject);    // 본인 삭제 !
    }
}
