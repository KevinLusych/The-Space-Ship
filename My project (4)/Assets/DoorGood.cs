using System.Collections;
using UnityEngine;

public class DoorGood : MonoBehaviour
{
    [Header("Door Parts")]
    public Transform downPartA;
    public Transform downPartB;
    public Transform upPart;

    [Header("Movement Settings")]
    public float slideSpeed = 2f;
    public float slideDistance = 3f;

    private Vector3 downAStart;
    private Vector3 downBStart;
    private Vector3 upStart;

    private Vector3 downATarget;
    private Vector3 downBTarget;
    private Vector3 upTarget;

    private bool playerInside = false;

    void Start()
    {
        downAStart = downPartA.position;
        downBStart = downPartB.position;
        upStart = upPart.position;

        downATarget = downAStart + Vector3.down * slideDistance;
        downBTarget = downBStart + Vector3.down * slideDistance;
        upTarget = upStart + Vector3.up * slideDistance;
    }

    void Update()
    {
        if (playerInside)
        {
            // Slide open
            downPartA.position = Vector3.MoveTowards(
                downPartA.position,
                downATarget,
                slideSpeed * Time.deltaTime
            );

            downPartB.position = Vector3.MoveTowards(
                downPartB.position,
                downBTarget,
                slideSpeed * Time.deltaTime
            );

            upPart.position = Vector3.MoveTowards(
                upPart.position,
                upTarget,
                slideSpeed * Time.deltaTime
            );
        }
        else
        {
            // Slide closed
            downPartA.position = Vector3.MoveTowards(
                downPartA.position,
                downAStart,
                slideSpeed * Time.deltaTime
            );

            downPartB.position = Vector3.MoveTowards(
                downPartB.position,
                downBStart,
                slideSpeed * Time.deltaTime
            );

            upPart.position = Vector3.MoveTowards(
                upPart.position,
                upStart,
                slideSpeed * Time.deltaTime
            );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInside = false;
    }
}
