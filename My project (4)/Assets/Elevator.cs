using System.Collections;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [Header("Elevator Parts")]
    public Transform platformA;
    public Transform platformB;

    [Header("Movement Settings")]
    public float moveSpeed = 2f;
    public float moveDistance = 5f;
    public float delayBeforeMove = 2f;

    private bool activated = false;

    private Vector3 startPosA;
    private Vector3 startPosB;
    private Vector3 targetPosA;
    private Vector3 targetPosB;

    private void Start()
    {
        startPosA = platformA.position;
        startPosB = platformB.position;

        targetPosA = startPosA + Vector3.up * moveDistance;
        targetPosB = startPosB + Vector3.up * moveDistance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!activated && other.CompareTag("Player"))
        {
            activated = true;
            StartCoroutine(MoveElevator());
        }
    }

    private IEnumerator MoveElevator()
    {
        yield return new WaitForSeconds(delayBeforeMove);

        while (Vector3.Distance(platformA.position, targetPosA) > 0.01f)
        {
            platformA.position = Vector3.MoveTowards(
                platformA.position,
                targetPosA,
                moveSpeed * Time.deltaTime
            );

            platformB.position = Vector3.MoveTowards(
                platformB.position,
                targetPosB,
                moveSpeed * Time.deltaTime
            );

            yield return null;
        }
    }
}
