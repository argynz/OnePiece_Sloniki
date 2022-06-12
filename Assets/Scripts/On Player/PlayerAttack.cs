using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public LayerMask enemyLayerMask;
    public float attackRange;
    public int damageAmount;

    public Animator animator;
    private int attackAnimHash;
    void Start()
    {
        attackAnimHash = Animator.StringToHash("Attack");
    }

    void Update()
    {
        // if (timeBtwAttack <= 0)
        // {
        //     if (Input.GetMouseButton(0))
        //     {
        //         animator.SetTrigger(attackAnimHash);
        //     }
        // } 
        // else
        // {
        //     timeBtwAttack -= Time.deltaTime;
        // }
    }
}
