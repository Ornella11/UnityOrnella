using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 1;
    public BoxCollider2D bc;

    public LayerMask obstaclesLayer ;
    public float distanceDetection =0.5f;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        rb.velocity = new Vector2(
            speed * transform.right.normalized.x,
            rb.velocity.y
        );
    }

    // Update is called once per frame
    private void OnDrawGizmos()
    {
     if (bc!= null)
     {
        Gizmos.DrawLine(
            bc.bounds.center,
            bc.bounds.center+ new Vector3(distanceDetection,0,0)
        );
     }   
    }

    public bool HasCollisionWithObstacle()
    {
        RaycastHit2D hit = Physics2D.Linecast(
            bc.bounds.center,
            bc.bounds.center + new Vector3(distanceDetection,0,0),
            obstaclesLayer
        );

        return hit.collider !=null;
    }
}
