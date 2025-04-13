using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ProjectileController : MonoBehaviour
{
    public float speed = 5f;
    public Transform target;
    public float damage;

    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            Vector3 directionToGate = (target.transform.position - transform.position).normalized;

            if (directionToGate != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(directionToGate);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
            }
        }
        else
        {
            Debug.LogWarning("Target is not assigned!");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Enemy")) // Assuming the enemy has an "Enemy" tag
       {
           // Call the TakeDamage method on the enemy's EnemyController
           EnemyController enemyController = other.GetComponent<EnemyController>();
           if (enemyController != null)
           {
               enemyController.takeDamage(damage); // Assuming a damage value of 1
           }
      
           // Destroy the bullet upon impact
           Destroy(gameObject);
       }
    }
}
