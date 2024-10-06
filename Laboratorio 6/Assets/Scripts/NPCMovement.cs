using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] private Transform[] walkPoints;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float waitingTime = 5f;
    [SerializeField] private GameObject dialoguePanel;
    private int currentPoint = 0;
    void Awake()
    {
        transform.position = walkPoints[0].position;
        StartCoroutine(Walk());
    }
    IEnumerator Walk()
    {
        while (true)
        {
            Transform target = walkPoints[currentPoint];
            while (Vector3.Distance(transform.position, target.position) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                yield return null;
            }
            yield return new WaitForSeconds(waitingTime);
            if (currentPoint < walkPoints.Length - 1)
            {
                currentPoint = currentPoint + 1;
            }
            else
            {
                currentPoint = 0;
            }
        }
    }
    IEnumerator Interact()
    {
        speed = 0f;
        dialoguePanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        dialoguePanel.SetActive(false);
        speed = 5f;
    }
}
