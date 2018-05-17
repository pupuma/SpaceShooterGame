using UnityEngine;
using System.Collections;

public class EnemyCtrl : SpaceShip 
{
    public int iMaxHp = 5;      // 최대 체력
    public int iCurrentHp;      // 현재 체력

    // 활성화 됐을때 부모의 OnEnable() 함수를 재정의(Override)
    protected override void OnEnable()
    {
        // 부모의 OnEnbale 함수를 호출해라.
        base.OnEnable();    // -> isShoot ? Shoot 코루틴 함수 진행

        GetComponent<Rigidbody2D>().velocity = (transform.up * -1) * fSpeed;
        iCurrentHp = iMaxHp;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Bullet(Player)")
            return;

        // 총알의 Power를 가져와서
        // 스크립트에 있는 변수 값을 가져오고싶다.
        // GameObject -> GetComponent<Script>
        BulletCtrl ObjCs = other.GetComponent<BulletCtrl>();

        // 현재 HP 깎는다.
        iCurrentHp -= ObjCs.iBulletDamage;

        // 충돌한 총알을 삭제한다.
        Destroy(other.gameObject);

        // 체력이 0이하가되면? 삭제
        if (iCurrentHp <= 0)
        {
            Explode();  // 삭제이전에 폭발이펙트 연출

            Destroy(this.gameObject);
        }
        else    // 데미지를 입었는데 안죽었을때,
            cAnimator.SetTrigger("isHit");
    }
}
