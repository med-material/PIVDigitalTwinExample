using UnityEngine;
using System.Collections;

public class GenerateHolyText : MonoBehaviour
{

    [SerializeField]
    private GameObject grass;

    [SerializeField]
    private GameObject holyTextTemplate;

    private float delay = 1f;

    private float adder = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewHolyText() {
        delay +=adder;
        StartCoroutine(SpawnNewHolyText(delay));
    }

    // every 2 seconds perform the print()
    private IEnumerator SpawnNewHolyText(float waitTime)
    {
            yield return new WaitForSeconds(waitTime);
            GameObject duplicate = Instantiate(holyTextTemplate);
            duplicate.SetActive(true);
            duplicate.GetComponent<MeshRenderer>().enabled = true;
            duplicate.name = "HolyText";
            Vector2 newpoint = Random.insideUnitCircle * (grass.GetComponent<Collider>().bounds.size.z/2);
            Debug.Log(newpoint.x);
            Debug.Log(newpoint.y);
            duplicate.transform.position = new Vector3(newpoint.x, duplicate.transform.position.y, newpoint.y);
    }
}
