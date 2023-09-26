using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Vector2 InputVec;
    Vector2 nextVec;
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        InputVec.x = Input.GetAxisRaw("Horizontal");
        InputVec.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        nextVec = InputVec.normalized * speed * Time.fixedDeltaTime;

        rigid.MovePosition(rigid.position + nextVec);
    }

    private void LateUpdate()
    {
        anim.SetFloat("Speed", InputVec.magnitude);

        if (InputVec.x != 0)
            spriter.flipX = InputVec.x < 0;
    }
}
