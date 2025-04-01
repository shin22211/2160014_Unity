using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //��� ���� ����
    float fMaxPositionX = 10.0f; //�÷��̾ ��,�� �̵��� ����â�� ����� �ʵ��� Vector �ִ� ���� ����
    float fMinPositionX = -10.0f;
    float fPositionX = 0.0f;    //�÷��̾ ��,�� �̵��� �� �ִ� X ��ǥ ���� ����
                                
    /* Start �޼���
     * �̸� ���ǵ� Ư�� �̺�Ʈ �Լ��ν�, �� Ư�� �Լ����� C# ������ �Լ��� �޼ҵ��� ��
     * MonoBehaviour Ŭ������ �ʱ�ȭ �� �� ȣ�� �Ǵ� �̺�Ʈ �Լ�
     * ���α׷��� ������ �� �� ���� ȣ���� �Ǵ� �Լ��� ���� ������Ʈ�� �޾ƿ��ų� ������Ʈ�� �ٸ� �Լ����� ����ϱ� ���� �ʱ�ȭ ���ִ� ���
     * ��, Start() �޼���� ��ũ��Ʈ �ν���Ʈ�� Ȱ��ȭ�� ��쿡�� ù ��° ������ ������Ʈ ���� ȣ���ϹǷ� �ѹ��� ����
     * �� ���¿� ���Ե� ��� ������Ʈ�� ���� Upadte �� ������ ȣ��� ��� ��ũ��Ʈ�� ���� Start1 �Լ��� ȣ��
     * ���� �����÷��� ���� ������Ʈ�� �ν��Ͻ�ȭ�� ���� ������� ����
     */
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /* ����̽� ���ɿ� ���� ���� ����� ���� ���ֱ�
         * � ������ ��ǻ�Ϳ��� �����ص� ���� �ӵ��� �����̵��� �ϴ� ó��
         * ����Ʈ���� 60, ����� PC�� 300�� �� �� �ִ� ����̽� ���ɿ� ���� ���� ���ۿ� ������ ��ĥ �� ����
         * �����ӷ���Ʈ�� 60���� ����
         */
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        /* Ű�� ���� ���� : GetKeyDown()
         * Ű�� ������ �ִ� ���� : GetKey()
         * Ű�� �����ٰ� �� ���� : GetKeyUp()
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
         * Math.Clamp(value,min, max) �޼���
         * Ư�� ���� ��� ������ ���ѽ�Ű���� �� �� ����ϴ� �޼���
         * value ���� ���� : min <= value <= max
         * �ּ�/�ִ밪�� �����Ͽ� ������ ���� �̿ܿ� ���� ���� �ʵ��� �� �� ���
         * �÷��̾ ������ �� �ִ� �ּ�(fMinPositionX)/�ִ�(fMaxPositionX) �������� �����Ͽ� �� ������ ����� �ʵ����Ѵ�.
        */


        fPositionX = Mathf.Clamp(transform.position.x, fMinPositionX, fMaxPositionX);
        transform.position = new Vector3(fPositionX, transform.position.y, transform.position.z);
    }
}
