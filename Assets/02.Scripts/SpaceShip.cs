using UnityEngine;
using System.Collections;

// 어트리뷰트(특성)
[RequireComponent(typeof(Rigidbody2D),typeof(Animator))]
// 이 스크립트가 적용된 객체에서, Rigidbody2D, Animator가 필요하다 !
// 만약에 스크립트가 적용된 객체에 두 가지 컴포넌트가 존재 하지 않는다면,
// 있다고 가정하고 플레이,
// 이미 추가가 되어있다면, 유저가 유니티UI에서 컴포넌트를 삭제 할 수 없다.


// Player와 Enemy의 부모가 될 SpaceShip
public class SpaceShip : MonoBehaviour 
{
    public float fSpeed;
    public float fShotDelay;
    public bool isShoot;
    protected Transform[] trShotPositionArr;
    public GameObject goBulletPrefab;
    protected Animator cAnimator;       // 애니메이터 컴포넌트
    public GameObject explosion;        // 폭발 이펙트 프리팹 받을 공간


    void Awake()
    {
        cAnimator = GetComponent<Animator>();
        trShotPositionArr = new Transform[transform.childCount];

        for (int i = 0; i < trShotPositionArr.Length; ++i)
            trShotPositionArr[i] = transform.GetChild(i);
    }

    protected virtual void OnEnable()
    {
        if (isShoot)
            StartCoroutine("Shoot");
    }

    IEnumerator Shoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(fShotDelay);

            // shoot 음원 재생
            AudioSource tmpAudio = GetComponent<AudioSource>();
            if (tmpAudio)
                tmpAudio.Play();    // 재생

            for(int i = 0; i < transform.childCount; ++i)
            {
                GameObject Obj = (GameObject)Instantiate(
                    goBulletPrefab,
                    trShotPositionArr[i].position,
                    trShotPositionArr[i].rotation);
            }
        }
    }

    protected void Explode()
    {
        // explosition(프리팹) 생성
        GameObject obj = Instantiate(explosion);

        // 프리팹 위치 조절(호출자(플레이어, 적)의 위치로 변경)
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
    }

}
