using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //멤버 변수 선언
    float fMaxPositionX = 10.0f; //플레이어가 좌,우 이동시 게임창을 벗어나지 않도록 Vector 최댓값 설정 변수
    float fMinPositionX = -10.0f;
    float fPositionX = 0.0f;    //플레이어가 좌,우 이동할 수 있는 X 좌표 저장 변수
                                
    /* Start 메서드
     * 미리 정의된 특수 이벤트 함수로써, 이 특수 함수들을 C# 에서는 함수를 메소드라고 함
     * MonoBehaviour 클래스가 초기화 될 때 호출 되는 이벤트 함수
     * 프로그램이 시작할 때 한 번만 호출이 되는 함수로 보통 컴포넌트를 받아오거나 업데이트나 다른 함수에서 사용하기 위해 초기화 해주는 기능
     * 즉, Start() 메서드는 스크립트 인스턴트가 활성화된 경우에만 첫 번째 프레임 업데이트 전에 호출하므로 한번만 진행
     * 씬 에셋에 포함된 모든 오브젝트에 대해 Upadte 등 이전에 호출된 모든 스크립트를 위한 Start1 함수가 호출
     * 따라서 게임플레이 도중 오브젝트를 인스턴스화될 때는 실행되지 않음
     */
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /* 디바이스 성능에 따른 실행 결과의 차이 없애기
         * 어떤 성능의 컴퓨터에서 동작해도 같은 속도로 움직이도록 하는 처리
         * 스마트폰은 60, 고속의 PC는 300이 될 수 있는 디바이스 성능에 따라 게임 동작에 영향을 미칠 수 있음
         * 프레임레이트를 60으로 고정
         */
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        /* 키를 누른 순간 : GetKeyDown()
         * 키를 누르고 있는 순간 : GetKey()
         * 키를 누르다가 땐 순간 : GetKeyUp()
         */      
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-3, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(3, 0, 0);
        }


        /*
         * Math.Clamp(value,min, max) 메서드
         * 특정 값을 어떠한 범위에 제한시키고자 할 때 사용하는 메서드
         * value 값의 범위 : min <= value <= max
         * 최소/최대값을 설정하여 지정한 범위 이외에 값이 되지 않도록 할 때 사용
         * 플레이어가 움직일 수 있는 최소(fMinPositionX)/최대(fMaxPositionX) 범위값을 설정하여 그 범위를 벗어나지 않도록한다.
        */


        fPositionX = Mathf.Clamp(transform.position.x, fMinPositionX, fMaxPositionX);
        transform.position = new Vector3(fPositionX, transform.position.y, transform.position.z);
    }
}
