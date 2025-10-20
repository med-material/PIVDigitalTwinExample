using UnityEngine;

public class TreeWind : MonoBehaviour
{

    [SerializeField]
    GameObject[] trees;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trees = GameObject.FindGameObjectsWithTag("Tree");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
