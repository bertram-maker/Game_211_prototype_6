using UnityEngine;

public class block_controller_script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject falling_floor;
    public float timer;
    public float xPos;

    public float start;
    public float end;
    public float increment;
    
    private float posIncrement;
    private float negIncrement;
    void Start()
    {
        timer = 0;
        xPos = -10 + increment;
        negIncrement = -increment;
        posIncrement = increment;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            Instantiate(falling_floor, new Vector3(xPos, 20, transform.position.z), Quaternion.identity);
            timer = 0;
            xPos += increment;
        }
        if (xPos >= end)
        {
            increment = negIncrement;
        }
        if (xPos <= start)
        {
            increment = posIncrement;
        }
    }
}
