using UnityEngine;
using System.Collections;

public class BackGroundCtrl : MonoBehaviour 
{
    public float fSpeed = 0.1f; // 배경이 스크롤되는 속도
	
	// Update is called once per frame
	void Update () 
    {
        // 시간 측정 함수
        /*
         1. float Time.delta
         이전 프레임에서 현재 프레임이 나오기까지 시간을 반환합니다.
         프레임이 다른기종(60, 30프레임) 두 기종 모두다 같은 스칼라량을 얻을 수 
         있다. 프레임에 전혀 영향 받지 않는 함수
         (물리량을 구할때 주로 사용한다.)
         
         2. float Time.time
         선언된 시점에서 카운트가 시작된다.
         */

        float y = Mathf.Repeat(Time.time * fSpeed, 1);
        // Time.time * fSpeed ~ 1 무한 반복하겠다.
        /*
         if(y > 1)
            y = 0;
         y += Time.time * fSpeed;
         */
        Vector2 offset = new Vector2(0, y);
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset
            ("_MainTex", offset);

        // _MainTex는 이미지 텍스처를 말하는 것이고,
        // _BumpMap은 BumpTex를 말하는 것이다.
        // 이런식으로 Offset을 설정하면, 슈팅게임의 배경을 연출할때 적절하다.
	}
}
