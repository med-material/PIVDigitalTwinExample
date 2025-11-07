using UnityEngine;
using TMPro;

public class CountDownText : MonoBehaviour
{

    [SerializeField]
    private TMP_Text lifeTimeCount;

    private int counter = -1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CountDown(float lifetime) {
        if (lifetime <= 1f) {
            lifeTimeCount.gameObject.SetActive(true);
            lifeTimeCount.text = "GAME OVER";
            counter = -1;            
        } else if (counter > (int) lifetime) {
            counter = (int) lifetime;
            lifeTimeCount.gameObject.SetActive(true);
            lifeTimeCount.text = counter.ToString();
        } else if (counter == -1) {
            counter = (int) lifetime;
            lifeTimeCount.gameObject.SetActive(true);
            lifeTimeCount.text = counter.ToString();
        }
    }
}
