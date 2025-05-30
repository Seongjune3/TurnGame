using UnityEngine;

public class GoToBoss : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = new Vector3(-1.336f, 12.48f, -19.86063f);
        }
    }
}
