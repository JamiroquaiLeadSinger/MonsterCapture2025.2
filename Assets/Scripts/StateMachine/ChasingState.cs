using UnityEngine;

public class ChasingState : iState
{
    GameObject player;
    GameObject ai;
    Rigidbody rb;

    // Constructor
    public ChasingState(GameObject player, GameObject ai, Rigidbody rb)
    {
        this.player = player;
        this.ai = ai;
        this.rb = rb;
    }

    public void Enter()
    {
        Debug.Log("Chase state enter");
    }

    public void Execute()
    {
        float wave = Mathf.Sin(Time.time * 20f) * 0.1f + 1f;
        float wave2 = Mathf.Cos(Time.time * 20f) * 0.1f + 1f;

        ai.transform.localScale = new Vector3(wave, wave2, wave);

        Vector3 direction = player.transform.position - ai.transform.position;
        rb.AddForce(direction * 0.5f);
    }

    public void Exit()
    {
        Debug.Log("Chase state exit");
    }
}
