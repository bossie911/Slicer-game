using UnityEngine;

public class ScraperMovement : MonoBehaviour
{
<<<<<<< HEAD
    public Rigidbody scraper;
    public bool scraperDown = false;
    public Vector3 velocity = new Vector3(0, 0, 2);
    public float strengthForward = 5;
    public float strengthUp = 5;
=======
    int interpolationFramesCount = 180; // Number of frames to completely interpolate between the 2 positions
    int elapsedFrames = 0;

    //Vector3 targetAngle = new Vector3(180f, 0f, 0f);
    Vector3 targetAngle;
    Vector3 currentAngle;

    public Rigidbody scraper;

    public void Start()
    {
        currentAngle = transform.eulerAngles;
        targetAngle = currentAngle;
        targetAngle.x = currentAngle.x + 180;
    }
>>>>>>> Mika

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if (Input.GetMouseButtonDown(0) || (Input.GetMouseButtonDown(0) && scraperDown))
        {
            scraper.AddForce(transform.forward * strengthForward, ForceMode.Impulse);
            scraper.AddForce(-transform.up * strengthUp, ForceMode.Impulse);
        }
        if (scraperDown && !Input.GetMouseButton(0))
        {
            scraper.velocity = velocity;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Scrapeable")
        {
            scraper.constraints = RigidbodyConstraints.FreezePositionX;
            scraper.constraints = RigidbodyConstraints.FreezeRotation;
            scraperDown = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Scrapeable")
        {
            scraper.constraints = RigidbodyConstraints.None;
            scraper.constraints = RigidbodyConstraints.FreezePositionX;
            scraper.constraints = RigidbodyConstraints.FreezeRotationY;
            scraper.constraints = RigidbodyConstraints.FreezeRotationZ;
            scraperDown = false;
        }
=======
        if (Input.GetButtonDown("Fire1"))
        {
            scraper.AddForce(new Vector3(0, 10, 5), ForceMode.Impulse);
            //scraper.AddTorque(new Vector3(10, 0, 0), ForceMode.Impulse);


        }
        
        float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;
        Quaternion interpolatedRotation = Quaternion.Lerp(Quaternion.Euler(0, 0, 0), Quaternion.Euler(359, 0, 0), interpolationRatio);
        //reset elapsedFrames to zero after it reached (interpolationFramesCount + 1)
        elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);
        transform.rotation = interpolatedRotation;
        

        /*
        currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime),
            Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime),
            Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime));

        transform.eulerAngles = currentAngle;
        */
>>>>>>> Mika
    }
} 
