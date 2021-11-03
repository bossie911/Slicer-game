using UnityEngine;

public class ScraperMovement : MonoBehaviour
{

    public Rigidbody scraper;
    public bool scraperDown = false;
    public Vector3 velocity = new Vector3(0, 0, 2);
    public float strengthForward = 5;
    public float strengthUp = 10;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) || (Input.GetMouseButtonDown(0) && scraperDown))
        {
            scraper.velocity = Vector3.zero;
            scraper.AddForce(transform.TransformDirection(transform.forward * strengthForward), ForceMode.Impulse);
            scraper.AddForce(transform.TransformDirection(-transform.up * strengthUp), ForceMode.Impulse);
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
            /*scraper.constraints = RigidbodyConstraints.None;
            scraper.constraints = RigidbodyConstraints.FreezePositionX;
            scraper.constraints = RigidbodyConstraints.FreezeRotation;*/
            scraperDown = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Scrapeable")
        {
            /*scraper.constraints = RigidbodyConstraints.None;
            scraper.constraints = RigidbodyConstraints.FreezePositionX;
            scraper.constraints = RigidbodyConstraints.FreezeRotation;*/
            scraperDown = false;
        }     
    }
} 
