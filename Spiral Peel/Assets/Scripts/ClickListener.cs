﻿using UnityEngine;
using UnityEngine.UI;

public class ClickListener : MonoBehaviour
{
    public Transform scraper;
    public GameObject spiralGeneratorPrefab;
    GameObject spiralGenerator;
    bool startedSpiral = false;

    // Update is called once per frame
    void Update()
    {
        // Check if the left mouse button is pressed and the scraper is up
        if (scraper.GetComponent<ScraperMovement>().scraperDown)
        {
            if (!startedSpiral)
            {
                // Create an instance of spiral generator and give it the scraper object to follow
                spiralGenerator = Instantiate(spiralGeneratorPrefab, Vector3.zero, Quaternion.identity);
                startedSpiral = true;
            }
            
        }

        // Check if the left mouse button is released and the scraper is down
        if (!scraper.GetComponent<ScraperMovement>().scraperDown)
        {
            // Tell the spiralGenerator to stop scraping
            if (spiralGenerator && startedSpiral)
            {
                MeshGenerator meshGenerator = spiralGenerator.GetComponent<MeshGenerator>();
                meshGenerator.StopScraping();

                int spiralSize = meshGenerator.spiralSize;

                spiralGenerator.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(transform.forward * 15), ForceMode.Impulse);
                spiralGenerator.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(transform.up * 30), ForceMode.Impulse);
                startedSpiral = false;
            }
        }
    }
}
