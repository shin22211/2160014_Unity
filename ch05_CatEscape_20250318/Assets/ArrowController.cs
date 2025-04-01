//화살이 위에서 아래로 1초에 하나씩 떨어지는 기능 --> transform.Translate()
// 화살이 게임화면 밖으로 나오면 화살 오브젝트를 소멸시키는 기능 --> Destroyt()




using UnityEngine;

public class ArrowController : MonoBehaviour
{

    //멤버변수 선언
    GameObject gPlayer = null; // Player Object를 저장한 GameObject 변수, GameObject 변수의 초기값은 null

    Vector2 vArrowCirclePoint = Vector2.zero; //화살들 둘러싼 원의 중심 좌표
    Vector2 vPlayerCirclePoint = Vector2.zero; //플레이어를 둘러싼 원의 중심
    Vector2 vArrowPlayerDir = Vector2.zero; //화살에서 플레이어까지의 벡터값

    float fArrowRadius = 0.5f;  // 화살 원의 반지름 0.5
    float fPlayerRadius = 1.0f; // 플레이어 원의 반지름 1.0
    float fArrowPlayerDistance = 0.0f; // 화살의 중심(vArrowCirclePoint)부터 플레이어를 둘러싼 원의 중심(vPlayerCirclePoint)까지 거리



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gPlayer = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * 화살이 위에서 아래로 1초에 하나씩 떨어지는 기능 transform.Translate()
         * 메모리가 낭비되지 않도록 화살이 화면 밖으로 나가면 오브젝트를 소멸시켜야 함
         * 매개변수로 자신을 가르키는 gameObject 변수를 전달하므로 화살이 화면 밖으로 나갈때 자기 자신을 소멸시킴
         */
            transform.Translate(0, -0.1f, 0);

        if(transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        /*
         * 충돌판정 : 원의 중심 좌표와 반경을 사용한 충돌 판정 알고리즘
         * 화살의 중심(vArrowCirclePoint)부터 플레이어를 둘러싼 원의 중심(vPlayerCirclePoint)까지 거리(fArrowPointDistance)를 피타고라스 정리를 이용하여 구한다.
         * 
         * 
         * 
         * 두 원의 중심간의 거리 fArrowPlayerDistance > fArrowRadius + fPlayerRadius : 충돌하지 않음
         * 두 원의 중심간의 거리 fArrowPlayerDistance < fArrowRadius + fPlayerRadius : 충돌함
         * 
         * 
         * 
         */ 
        vArrowCirclePoint = transform.position;
        vPlayerCirclePoint = gPlayer.transform.position;
        vArrowPlayerDir = vArrowCirclePoint - vPlayerCirclePoint;

        fArrowPlayerDistance = vArrowPlayerDir.magnitude;


        /*
         * 플레이어가 화살에 맞았는지 감지, 즉 화살과 플레이어의 충돌 판정
         * 원의 중심 좌표와 반경을 사용해 충돌 판정
         * r1 : 화살을 둘러싼 원의 반지름
         * r2 : 플레이어를 둘러싼 원의 반지름
         * d : 화살원 중심에서 플레이어원 중심까지 거리
         * 미충돌 : 두 원의 중심 간 거리 d가(r1 + r2) 보다 크면 두 원은 충돌하지 않음(d > r1+r2)
         * 충돌(fArrowPlayerDistance < ( FArrowRadius + fPlayerRadius)) 이면 화살 오브젝트 소멸
         */

        if(fArrowPlayerDistance < fArrowRadius + fPlayerRadius)
        {
            Destroy(gameObject); // 화살과 플레이어의 충돌, 화살 오브젝트를 소멸
        }


    }
}
