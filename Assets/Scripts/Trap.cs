using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour
{
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collider other)
    {
        if(other.TryGetComponent<iTrappable>(out iTrappable pal))
        {
            if (pal.isBeingCaptured) return;

            Debug.Log("Increase score by" + pal.PointValue());
            StartCoroutine(Capture(pal, other.gameObject));
        }
    }

    IEnumerator Capture (iTrappable pal, GameObject palGO)
    {
        bool isAnimationPlaying = true;
        float scale = gameObject.transform.localScale.x;

        while (isAnimationPlaying)
        {
            rb.isKinematic = true;

            float wave = Mathf.Sin(Time.time * 20f) * 0.1f + scale;

            isAnimationPlaying = pal.CaptureAnimation();
            yield return null;
        }

        rb.isKinematic = false;
        Destroy(palGO);
    }
}
