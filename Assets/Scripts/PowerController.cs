using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PowerMode
{
    Create,Destroy,GravityControl
}

public class PowerController : MonoBehaviour
{
    [SerializeField] GameObject Matheris;
    [SerializeField] GameObject DestroyParticles;
    [SerializeField] Image PowerModeImage;
    [SerializeField] Sprite[] PowerModeSprites;
    PowerMode powerMode;
    bool onmenu;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void noMenuPointEnter()
    {
        onmenu = true;
    }
    public void noMenuPointExit()
    {
        onmenu = false;
    }
    public void PowerIsCreate()
    {
        powerMode = PowerMode.Create;
    }
    public void PowerIsDestroy()
    {

        powerMode = PowerMode.Destroy;
    }
    public void PowerIsGravity()
    {

        powerMode = PowerMode.GravityControl;
    }
    void Render()
    {
        if (powerMode == PowerMode.Create)
        {
            PowerModeImage.sprite = PowerModeSprites[0];
        }
        if (powerMode == PowerMode.Destroy)
        {
            PowerModeImage.sprite = PowerModeSprites[1];
        }
        if (powerMode == PowerMode.GravityControl)
        {
            PowerModeImage.sprite = PowerModeSprites[2];
        }
    }
    // Update is called once per frame
    void Update()
    {
        Render();
        if (!onmenu) RunPower();
    }
    GameObject gravityObject;
    private void RunPower()
    {
        binarPower();
        if (Input.GetKey(KeyCode.Mouse0) && powerMode == PowerMode.GravityControl)
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider)
                {
                    if (hit.collider.gameObject.GetComponent<Rigidbody>())
                    {
                        hit.rigidbody.MovePosition(((hit.point - hit.transform.position) * Time.deltaTime * 6) + hit.transform.position);
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && powerMode == PowerMode.GravityControl)
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider)
                {
                    if (hit.collider.gameObject.GetComponent<Rigidbody>())
                    {
                        gravityObject = hit.collider.gameObject;
                    }
                }

            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) NoGravity();
        if (Input.GetKeyUp(KeyCode.Mouse0)) OnGravity();
        if (Input.GetKeyDown(KeyCode.Tab)) Return();
    }
    public void Return()
    {
    }
    public void NoGravity()
    {
        foreach (GameObject PoweredGameObject in GameObject.FindGameObjectsWithTag("GodPowerObject"))
        {
            if (PoweredGameObject.GetComponent<Rigidbody>())
            {
                PoweredGameObject.GetComponent<Rigidbody>().useGravity = false;
                PoweredGameObject.GetComponent<Rigidbody>().mass = 10.0f;
                PoweredGameObject.GetComponent<Rigidbody>().drag = 10;
                PoweredGameObject.GetComponent<Rigidbody>().angularDrag = 7;
            }
        }
    }
    public void OnGravity()
    {

        if (gravityObject)
        {
            if (gravityObject.GetComponent<Rigidbody>())
            {
                gravityObject.GetComponent<Rigidbody>().useGravity = true;
                gravityObject.GetComponent<Rigidbody>().mass = 1.0f;
                gravityObject.GetComponent<Rigidbody>().drag = 0;
                gravityObject.GetComponent<Rigidbody>().angularDrag = 0.5f;
            }
        }

    }

    private void binarPower()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && powerMode == PowerMode.Create)
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider)
                {
                    Instantiate(Matheris, hit.point, Random.rotationUniform);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && powerMode == PowerMode.Destroy)
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider)
                {
                    if (hit.collider.tag == "GodPowerObject")
                    {
                        Instantiate(DestroyParticles, hit.point, Random.rotationUniform);
                        Destroy(hit.collider.gameObject);

                    }
                }
            }
        }
    }
}
