//ȭ���� ������ �Ʒ��� 1�ʿ� �ϳ��� �������� ��� --> transform.Translate()
// ȭ���� ����ȭ�� ������ ������ ȭ�� ������Ʈ�� �Ҹ��Ű�� ��� --> Destroyt()




using UnityEngine;

public class ArrowController : MonoBehaviour
{

    //������� ����
    GameObject gPlayer = null; // Player Object�� ������ GameObject ����, GameObject ������ �ʱⰪ�� null

    Vector2 vArrowCirclePoint = Vector2.zero; //ȭ��� �ѷ��� ���� �߽� ��ǥ
    Vector2 vPlayerCirclePoint = Vector2.zero; //�÷��̾ �ѷ��� ���� �߽�
    Vector2 vArrowPlayerDir = Vector2.zero; //ȭ�쿡�� �÷��̾������ ���Ͱ�

    float fArrowRadius = 0.5f;  // ȭ�� ���� ������ 0.5
    float fPlayerRadius = 1.0f; // �÷��̾� ���� ������ 1.0
    float fArrowPlayerDistance = 0.0f; // ȭ���� �߽�(vArrowCirclePoint)���� �÷��̾ �ѷ��� ���� �߽�(vPlayerCirclePoint)���� �Ÿ�



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gPlayer = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * ȭ���� ������ �Ʒ��� 1�ʿ� �ϳ��� �������� ��� transform.Translate()
         * �޸𸮰� ������� �ʵ��� ȭ���� ȭ�� ������ ������ ������Ʈ�� �Ҹ���Ѿ� ��
         * �Ű������� �ڽ��� ����Ű�� gameObject ������ �����ϹǷ� ȭ���� ȭ�� ������ ������ �ڱ� �ڽ��� �Ҹ��Ŵ
         */
            transform.Translate(0, -0.1f, 0);

        if(transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        /*
         * �浹���� : ���� �߽� ��ǥ�� �ݰ��� ����� �浹 ���� �˰���
         * ȭ���� �߽�(vArrowCirclePoint)���� �÷��̾ �ѷ��� ���� �߽�(vPlayerCirclePoint)���� �Ÿ�(fArrowPointDistance)�� ��Ÿ��� ������ �̿��Ͽ� ���Ѵ�.
         * 
         * 
         * 
         * �� ���� �߽ɰ��� �Ÿ� fArrowPlayerDistance > fArrowRadius + fPlayerRadius : �浹���� ����
         * �� ���� �߽ɰ��� �Ÿ� fArrowPlayerDistance < fArrowRadius + fPlayerRadius : �浹��
         * 
         * 
         * 
         */ 
        vArrowCirclePoint = transform.position;
        vPlayerCirclePoint = gPlayer.transform.position;
        vArrowPlayerDir = vArrowCirclePoint - vPlayerCirclePoint;

        fArrowPlayerDistance = vArrowPlayerDir.magnitude;


        /*
         * �÷��̾ ȭ�쿡 �¾Ҵ��� ����, �� ȭ��� �÷��̾��� �浹 ����
         * ���� �߽� ��ǥ�� �ݰ��� ����� �浹 ����
         * r1 : ȭ���� �ѷ��� ���� ������
         * r2 : �÷��̾ �ѷ��� ���� ������
         * d : ȭ��� �߽ɿ��� �÷��̾�� �߽ɱ��� �Ÿ�
         * ���浹 : �� ���� �߽� �� �Ÿ� d��(r1 + r2) ���� ũ�� �� ���� �浹���� ����(d > r1+r2)
         * �浹(fArrowPlayerDistance < ( FArrowRadius + fPlayerRadius)) �̸� ȭ�� ������Ʈ �Ҹ�
         */

        if(fArrowPlayerDistance < fArrowRadius + fPlayerRadius)
        {
            Destroy(gameObject); // ȭ��� �÷��̾��� �浹, ȭ�� ������Ʈ�� �Ҹ�
        }


    }
}
