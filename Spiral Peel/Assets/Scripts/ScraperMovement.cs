using UnityEngine;
using System.Collections;

public class ScraperMovement : MonoBehaviour
{

    public Rigidbody scraper;
    public bool scraperDown = false;
    public Vector3 velocity = new Vector3(0, 0, 2);
    public float strengthForward = 5;
    public float strengthUp = 10;

    private bool canRotate = true;

    private bool scrapingOnCooldown = false;
    private float scrapingCooldown = 0.5f;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) || (Input.GetMouseButtonDown(0) && scraperDown))
        {
            scraper.velocity = Vector3.zero;
            scraper.AddForce(transform.TransformDirection(transform.forward * strengthForward), ForceMode.Impulse);
            scraper.AddForce(transform.TransformDirection(-transform.up * strengthUp), ForceMode.Impulse);
            if (canRotate)
            {
                canRotate = false;
                StartCoroutine(Rotate());
            }
        }
        if (scraperDown && !Input.GetMouseButton(0))
        {
            scraper.velocity = velocity;
        }
    }

    IEnumerator Rotate()
    {
        float elapsed = 0f;
        float duration = 0.25f;
        var startRotation = transform.rotation;
        var endRotation = transform.rotation * Quaternion.Euler(180, 0, 0);
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsed/duration);
            yield return null;
        }
        StartCoroutine(Rotate2());
    }
    IEnumerator Rotate2()
    {
        float elapsed = 0f;
        float duration = 0.25f;
        var startRotation = transform.rotation;
        var endRotation = transform.rotation * Quaternion.Euler(180, 0, 0);
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsed / duration);
            yield return null;
        }
        canRotate = true;
    }

    IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(scrapingCooldown);
        scrapingOnCooldown = false; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Scrapeable" && !scrapingOnCooldown)
        {
            scraperDown = true;

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Scrapeable")
        {
            scraperDown = false;
            scrapingOnCooldown = true;
            StartCoroutine("ResetCooldown");
        }     
    }
} 
