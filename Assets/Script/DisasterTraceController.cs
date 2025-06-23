using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisasterTraceController : MonoBehaviour
{
    public LayerMask obstacleLayer;

    public float moveSpeed = 0.5f;
    public float raycastDistance = 2f;
    public float traceDistance = 2f;

    public float MinDestroyInterval = 1.0f;
    public float MaxDestroyInterval = 3.0f;

    public float timer = 0.0f;
    public float DestroyMonsterTime;

    private Transform player;
    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        DestroyMonster();
    }

    // Update is called once per frame
        void Update()
    {
        timer += Time.deltaTime;

        if (timer >= DestroyMonsterTime)
        {
            Destroy(gameObject);
        }

        Vector2 direction = player.position - transform.position;

        if (player.position.x < transform.position.x)
        {
            // 플레이어가 왼쪽에 있을 때
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            // 플레이어가 오른쪽에 있을 때
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (direction.magnitude > traceDistance)
            return;

        Vector2 directionNormalized = direction.normalized;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionNormalized, raycastDistance, obstacleLayer);
        Debug.DrawRay(transform.position, directionNormalized * raycastDistance, Color.red);

       
            if (hit.collider != null && hit.collider.CompareTag("Obstacle"))
            {
                Vector3 alternativeDirection = Quaternion.Euler(0f, 0f, -90f) * direction;
                transform.Translate(alternativeDirection * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(directionNormalized * moveSpeed * Time.deltaTime);
            }
    }

    void DestroyMonster()
    {
        DestroyMonsterTime = Random.Range(MinDestroyInterval, MaxDestroyInterval);
    }
}
