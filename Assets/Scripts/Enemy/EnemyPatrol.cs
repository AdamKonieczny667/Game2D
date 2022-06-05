using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rigthEdge;

    [SerializeField] private Transform enemy;

    [SerializeField] private float speed;
    private bool movingLeft;

    [SerializeField] private float idleDuration;
    private float idleTimer;

    [SerializeField] private Animator anim;

    private Vector3 initScale;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    public void OnDisable()
    {
        anim.SetBool("moving", false);
    }

    private void Update()
    {
        
        if(movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
            MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        else
        {   
            if(enemy.position.x <= rigthEdge.position.x)
            MoveInDirection(1);
            else
            {
                DirectionChange();
            }
        }
        
    }

    private void DirectionChange()
    {
        anim.SetBool("moving", false);
        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration)
            movingLeft = !movingLeft;

        
    }


    private void MoveInDirection(int _direction)

    {
        idleTimer = 0;
        anim.SetBool("moving", true);
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,initScale.y,initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
        enemy.position.y, enemy.position.z);
    }
}