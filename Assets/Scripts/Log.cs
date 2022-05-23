using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : EnemyController
{
    private Rigidbody myRigidbody;
    private Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Animator anim;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance(){
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            changeAnim(temp - transform.position);
            myRigidbody.MovePosition(temp);
            anim.SetBool("wakeup", true);
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            anim.SetBool("wakeup", false);
        }
    }

    private void SetAnimFloat(Vector3 setVector){
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }

    private void changeAnim(Vector3 direction){
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0){
                SetAnimFloat(Vector3.right);
            }else if (direction.x < 0)
            {
                SetAnimFloat(Vector3.left);
            }
        }else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y)){
            if(direction.y > 0)
            {
                SetAnimFloat(Vector3.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector3.down);
            }
        }
    }
}
