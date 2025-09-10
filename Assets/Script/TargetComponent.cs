using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetComponent : MonoBehaviour
{
    private Renderer targetRenderer; 
    private Color originalColor;
    private Color hitColor = Color.green;

    // Start is called before the first frame update
    void Start()
    {
        targetRenderer = GetComponent<Renderer>();

        if(targetRenderer != null)
        {
            originalColor = targetRenderer.material.color;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
            GameManager.Instance.IncrementScore();

            // Change the color
            if(targetRenderer != null)
            {
                targetRenderer.material.color = hitColor;
            }

            // Restore the color and hide the target after 5 seconds

            Invoke("ResetColor", 5f);
        }
    }
    
    private void ResetColor()
    {
        if(targetRenderer != null)
        {
            targetRenderer.material.color = originalColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
