using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyState{
    idle,
    walk,
    attack,
    stagger
}
public class EnemyController : MonoBehaviour
{
    //public EnemyState currentState;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;

    public void Knock(Rigidbody myRigidbody, float knockTime)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        //TakeDamage(damage);
    }

    private IEnumerator KnockCo(Rigidbody myRigidbody, float knockTime)
    {
        // if (myRigidbody != null)
        // {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector3.zero;
            //currentState = EnemyState.idle;
            myRigidbody.velocity = Vector3.zero;
        // }
    }

     
}
