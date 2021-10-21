using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public int maxammo = 10;
    private int currentammo;

    public TMPro.TextMeshProUGUI ammmoCount;
    public TMPro.TextMeshProUGUI ammoHeader;
    public TMPro.TextMeshProUGUI reloadText;
    public TMPro.TextMeshProUGUI reloadTextIntruction;
    private float textAlpha;

    public GameObject line;
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    public Transform casingExitLocation;

    public AudioSource source;
    public AudioClip fire;
    public AudioClip reload;
    public AudioClip noammo; 

    public bool shoot = false;

    public float shotPower = 100f;

    void Start()
    {
        reloadText.enabled = false;
        if (barrelLocation == null)
            barrelLocation = transform;

        Reload();
    }

    void Reload() {
        currentammo = maxammo;
        
        ammoHeader.enabled = true;
        ammmoCount.enabled = true;
        reloadText.enabled = false;
        reloadTextIntruction.enabled = false;
        gameObject.transform.Find("Cylinder").gameObject.GetComponent<Renderer>().material.SetColor("Color_35DA217C", Color.green);

        source.PlayOneShot(reload);
    }

    void Update() {

        if (shoot) {
            Shoot();
        }

        // if (currentammo > 0) {
        //     GetComponent<Animator>().SetTrigger("Fire");
        // } else  {
        //         source.PlayOneShot(noammo);
        // }

        if (Vector3.Angle(transform.up, Vector3.up) > 100 && currentammo < maxammo) {
            Reload();
        }

        if (currentammo == 0) {
            ammoHeader.enabled = false;
            ammmoCount.enabled = false;
            reloadText.enabled = true;
            reloadTextIntruction.enabled = true;
            animateText();
        }

        ammmoCount.text = currentammo.ToString();
    }


    void animateText() {
        gameObject.transform.Find("Cylinder").gameObject.GetComponent<Renderer>().material.SetColor("Color_35DA217C", Color.red);

        float lerp = Mathf.PingPong(Time.time, 1f) / 1f;
        textAlpha = Mathf.Lerp(0.0f, 1.0f, Mathf.SmoothStep(0.0f, 1.0f, lerp));
        Color32 textColor =  new Color(255, 255, 255, textAlpha);
        reloadText.color = textColor;
        reloadTextIntruction.color = textColor;
    }

    public void Shoot() {
        //  GameObject bullet;
        //  bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        // bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

        if (currentammo == 0) {
            
            source.PlayOneShot(noammo);

        } else {

            currentammo--;
            source.PlayOneShot(fire);

            GameObject tempFlash;

            // float playerSpeed = 0;

            if (bulletPrefab)
                Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower, ForceMode.VelocityChange);
           	tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            RaycastHit hitInfo;
            bool hasHit = Physics.Raycast(barrelLocation.position, barrelLocation.forward, out hitInfo, 100f);

            if (hasHit)  {
            	Debug.Log(hitInfo.transform.name);
                hitInfo.collider.SendMessageUpwards("Dead", hitInfo.point, SendMessageOptions.DontRequireReceiver);
            }

            if(line)
            {
                GameObject liner = Instantiate(line);
                liner.GetComponent<LineRenderer>().SetPositions(new Vector3[] { barrelLocation.position , barrelLocation.position + barrelLocation.forward * 100 });

                Destroy(liner, 0.05f);
            }

           // Destroy(tempFlash, 0.5f);
            //  Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation).GetComponent<Rigidbody>().AddForce(casingExitLocation.right * 100f);
           // CasingRelease();
       }
    }

    void CasingRelease() {
        GameObject casing;
        casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
    }


}