using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("breakable"))
        {
            other.GetComponent<Rock>().Smash();
        }
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody enemy = other.GetComponent<Rigidbody>();
            // if (enemy != null)
            // {
            Debug.Log("Hit");
            //enemy.isKinematic = false;
            Vector3 difference = enemy.transform.position - transform.position;
            difference = difference.normalized * thrust;
            enemy.AddForce(difference, ForceMode.Impulse);
            if (other.gameObject.CompareTag("Enemy") && other.isTrigger)
            {
                other.GetComponent<EnemyController>().Knock(enemy, knockTime);
            }
            if (other.gameObject.CompareTag("Player"))
            {

                enemy.GetComponent<PlayerController>().currentState = PlayerState.stagger;
                other.GetComponent<PlayerController>().Knock(knockTime);

            }
            // }
        }
    }
}