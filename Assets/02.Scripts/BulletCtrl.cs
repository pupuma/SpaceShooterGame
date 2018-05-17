using UnityEngine;
using System.Collections;

public class BulletCtrl : MonoBehaviour 
{
    public float fBulletSpeed = 10.0f;
    public float fLifeTime = 1.0f;
    public int iBulletDamage = 1;

    // 유니티에서 예약된함수, 생성되거나, Active가 True가 되었을때 호출이 되는 함수
    void OnEnable()
    {
        // 총알의 본인의 Up 방향으로 스피드만큼 지속적으로 진행해라.
        GetComponent<Rigidbody2D>().velocity = transform.up * fBulletSpeed;

        // fLifetime 이후에는 스스로 소멸해라 !
        Invoke("SelfDestruction", fLifeTime);
    }

    void SelfDestruction()
    {
        Destroy(this.gameObject);
    }

}
