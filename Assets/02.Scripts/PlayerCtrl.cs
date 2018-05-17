using UnityEngine;
using System.Collections;

public class PlayerCtrl : SpaceShip 
{
	// Update is called once per frame
	void Update () 
    {
	    // 키보드 입력을 받는다.
        float h = Input.GetAxisRaw("Horizontal");  // 좌우 입력값
        float v = Input.GetAxisRaw("Vertical");    // 상하 입력값
        // GetAxis
        // -1.0f ~ +1.0f 사이의값으로, 아무것도안누르면, 서서히 0으로 돌아간다.
        // 키를 누르면 서서히 1.0f로 가까워진다.
        // GetAxisRaw
        // -1.0f, 0.0f, 1.0f 세가지로 들어온다.
        //Debug.Log("h : " + h);
        //Debug.Log("v : " + v);
        
        // h, v를 플레이어가 입력한 방향으로 취급한다.
        // h, v를 이용해서 방향 벡터를 만든다.
        // 위치 += 방향 * 속도 * 시간;
 
        // 1. 입력값을 벡터로 만든다.
        Vector2 direction = new Vector2(h, v);

        // 2. 크기를 1로만드는 정규화 진행
        direction.Normalize();

        // Move()호출 !
        Move(direction);
	}

    // 인자로 이동할 방향을 받아, 이동처리를 해주는 함수
    void Move(Vector2 direction)
    {
        Vector2 vPos = transform.position;
        vPos += direction * fSpeed * Time.deltaTime;

        // vPos을 구했고, 화면 밖을 못벗어나도록 설정한다.
        // 원리 : 메인 카메라를 가져와서 뷰포트좌표 -> 월드좌표 변환
        // 카메라의 절두체 공간을 UV좌표(0,0) ~ (1,1)라는 좌표로 했을때
        // 각각 min, max를 받아온다.

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        vPos.x = Mathf.Clamp(vPos.x, min.x, max.x);
        vPos.y = Mathf.Clamp(vPos.y, min.y, max.y);
        // vPos.x 를 min.x ~ max.x 사이로 강제 시켜라.
        /*
         if(vPos.x < min.x)
            vPos.x = min.x;
         if(vPos.x > max.x)
            vPos.x = max.x;
         */

        transform.position = vPos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bullet(Enemy)")
        {
            Destroy(other);     // 플레이어와 충돌한 총알 삭제
            
            Explode();  // 플레이어가 사망했을때, 삭제전 해당위치에 폭발
                        // 이펙트 연출 !

            Destroy(gameObject);    // 플레이어 삭제 !
        }
    }

}
