using UnityEngine;

public class Wasp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Sting();
    }

    void Sting() {
        Vector3 forward = transform.TransformDirection(Vector3.forward * 10);
        Debug.DrawRay(transform.position, forward, Color.yellow);
    }

}
