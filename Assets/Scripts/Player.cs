using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    public Scanner scanner;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
    }

   void Update()
    {
       /*inputVec.x = Input.GetAxisRaw("Horizontal"); //Raw�� ��Ȯ�� ��Ʈ�� ����
       inputVec.y = Input.GetAxisRaw("Vertical");*/
    }

    //������ ���ؼ��� FixedUpadate�� �̿�
    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    private void LateUpdate() //�������� ���� �Ǳ� �� ����Ǵ� �����ֱ� �Լ�
    {
        anim.SetFloat("Speed", inputVec.magnitude); //magnitude : ������ ������ ũ�� ��

        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0 ;
        }
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
