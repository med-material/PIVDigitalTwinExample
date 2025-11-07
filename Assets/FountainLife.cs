using UnityEngine;
using UnityEngine.UI;

public class FountainLife : MonoBehaviour
{

    private ParticleSystem water;

    private float maxTime = 30f;
    private float lifetime = 30f;
    private float maxBurst = 500f;
    private float multiplier = 1f;

    [SerializeField]
    private float[] burstThresholds;
    private int currentThreshold = 0;

    [SerializeField]
    private CountDownText countDown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        water = GetComponent<ParticleSystem>();
        maxTime = burstThresholds[currentThreshold];
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime < burstThresholds[currentThreshold]) {
            ParticleSystem.EmissionModule psEmission = water.emission;
            psEmission.rateOverTime = (int) Mathf.Lerp(0f,maxBurst,(lifetime/maxTime) * multiplier);
            if (currentThreshold < burstThresholds.Length-1) {
                currentThreshold++;
                //Debug.Log(currentThreshold);
                //Debug.Log(burstThresholds[currentThreshold]);
                multiplier = 1f - ((currentThreshold/10f));
            }
        }

        if (lifetime < 6f) {
            countDown.CountDown(lifetime);
        }
    }

    public void NewLife(int holyTextCount) {
        lifetime = (maxTime / 5) * holyTextCount;
        ParticleSystem.EmissionModule psEmission = water.emission;
        psEmission.rateOverTime = (int) Mathf.Lerp(0f,maxBurst,(lifetime/maxTime) * multiplier);

        for (int i = 0; i < burstThresholds.Length; i++) {
            //Debug.Log(burstThresholds[currentThreshold]);
            //Debug.Log(lifetime);
            if (burstThresholds[currentThreshold] < lifetime) {
                currentThreshold = i;
                multiplier = 1f - ((currentThreshold/10f));
                //Debug.Log(currentThreshold);
                break;
            }
        }
    }
}
