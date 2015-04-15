using UnityEngine;
using System.Collections;

public class VomitoController : MonoBehaviour {

    public UnityStandardAssets._2D.PlatformerCharacter2D p2D;
    public float minPower = 10f;
    public float maxPower = 100f;
    public float powerSpeed = 10f;
    private ParticleGenerator pg;
    public float power;

	// Use this for initialization
	void Start () {
        pg = GetComponentInChildren<ParticleGenerator>();
        pg.enabled = false;
        power = minPower;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {

            power += Time.deltaTime * powerSpeed;

            if (power > maxPower)
                power = maxPower;

            pg.enabled = true;
            
            if (p2D.FacingRight)
                pg.particleForce = new Vector3(power, power, 0f);
            else
                pg.particleForce = new Vector3(-power, power, 0f);
        }
        else
        {
            pg.enabled = false;
            power -= Time.deltaTime * powerSpeed;
            if (power < minPower)
                power = minPower;
        }
	}
}
