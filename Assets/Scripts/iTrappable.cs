using UnityEngine;

public interface iTrappable
{
    public bool isBeingCaptured { get; set; }

    public bool CaptureAnimation();
    public int PointValue();
}
