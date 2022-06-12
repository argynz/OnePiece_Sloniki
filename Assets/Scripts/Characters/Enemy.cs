using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float health = 0f;
    [SerializeField] private float maxHealth = 10f;

    [SerializeField] private float attackDamage = 2f;
    [SerializeField] private float attackSpeed = 2f;

    public Transform player;
    private Vector2 movement;
    public float moveSpeed = 0.5f;
    float rotationSpeed = 2f;
    private Rigidbody rb;

    private void Start()
    {
        health = maxHealth;
        rb = this.GetComponent<Rigidbody>();
    }
    void Update(){
        Vector3 direction = player.transform.position - transform.position;
        //Debug.Log(direction);
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Vector3 targetPosition = player.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        
        targetRotation.z = 0;
        targetRotation.x = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate() {
        moveCharacter(movement);
    }
    void moveCharacter(Vector3 direction){
        rb.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
