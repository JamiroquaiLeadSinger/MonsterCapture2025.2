using UnityEngine;

public class Barrel : MonoBehaviour, iTrappable
{
    private bool _beingCaptured = false;
    public bool isBeingCaptured { get => _beingCaptured; set => _beingCaptured = value; }

    public bool CaptureAnimation()
    {
        float wave = Mathf.Lerp();
        transform.localScale = new Vector3(wave, wave, wave);
        return true;
    }

    public int PointValue()
    {
        return 1;
    }
}
