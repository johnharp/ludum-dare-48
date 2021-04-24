using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeArray : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToDestroy;

    [SerializeField]
    private GameObject[] explosionGameObjects;

    [SerializeField]
    private Vector3 InitialScale = Vector3.one;
    [SerializeField]
    private Vector3 FinalScale = Vector3.one * 4.0f;
    [SerializeField]
    private float Speed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Lerp());
    }


    private IEnumerator Lerp()
    {
        float progress = 0.0f;

        while (progress <= 1.0f)
        {
            foreach (var obj in explosionGameObjects)
            {
                Vector3 dir =
                    (obj.transform.position - transform.position).normalized;
                Vector3 targetPosition = dir * 10.0f;

                //obj.transform.position =
                //    Vector3.Lerp(transform.position, targetPosition, progress);
                obj.transform.localScale =
                    Vector3.Lerp(InitialScale, FinalScale, progress);
            }
            progress += Time.deltaTime * Speed;
            yield return null;
        }

        Destroy(objectToDestroy);
        Destroy(gameObject);
    }
}
