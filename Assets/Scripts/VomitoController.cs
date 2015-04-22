using UnityEngine;
using System.Collections;

public class VomitoController : MonoBehaviour {

    public UnityStandardAssets._2D.PlatformerCharacter2D p2D;
    public float minPower = 10f;
    public float maxPower = 100f;
    public float powerSpeed = 10f;
    private ParticleGenerator pg;
    private float power;
    public float rotateSpeed = 5f;
    public float maxAngle = 90f;
    public float minAngle = -90f;
    public float currentAngle = 0;

	// Use this for initialization
	void Start () {
        pg = GetComponentInChildren<ParticleGenerator>();
        pg.enabled = false;
        power = minPower;
	}
	
	// Update is called once per frame
	void Update () {
        float v = Input.GetAxis("Vertical");
        float angle = v * rotateSpeed * Time.deltaTime;

        if (currentAngle + angle > maxAngle)
            angle = 0;
        if (currentAngle + angle < minAngle)
            angle = 0;

        currentAngle += angle;
        transform.Rotate(transform.forward, angle);

        if (Input.GetButton("Fire1"))
        {

            power += Time.deltaTime * powerSpeed;

            if (power > maxPower)
                power = maxPower;

            pg.enabled = true;

            if (p2D.FacingRight)
                pg.particleForce = transform.right * power;
            else
                pg.particleForce = -transform.right * power;
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
