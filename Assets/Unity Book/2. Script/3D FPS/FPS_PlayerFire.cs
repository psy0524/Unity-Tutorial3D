using System.Collections;
using TMPro;
using UnityEngine;

public class FPS_PlayerFire : MonoBehaviour
{
    private enum WeaponMode { Normal, Sniper  };
    private WeaponMode wMode;
    
    public GameObject firePosition;

    public GameObject bombFactory;

    private Animator anim;

    public float throwPower = 10f;
    public int weaponPower = 5;

    public GameObject bulletEffect;
    public ParticleSystem ps;
    public TextMeshProUGUI wModeText;
    public GameObject[] eff_Flash;

    public GameObject weapon01;
    public GameObject weapon02;

    public GameObject crossHair01;
    public GameObject crossHair02;

    public GameObject weapon01_R;
    public GameObject weapon02_R;

    private bool zoomMode = false;

    private void Start()
    {
        ps = bulletEffect.GetComponent<ParticleSystem>();
        anim = GetComponentInChildren<Animator>();

        wMode = WeaponMode.Normal;
    }

    private void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
        {
            if(anim.GetFloat("MoveMotion") == 0)
            {
                anim.SetTrigger("Attack");

            }
            StartCoroutine(ShootEffectOn(0.05f));
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo = new RaycastHit();

            if(Physics.Raycast(ray, out hitInfo))
            {
                if(hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    EnemyFSM eFSM = hitInfo.transform.gameObject.GetComponent<EnemyFSM>();
                    eFSM.HitEnemy(weaponPower);
                }
                else
                {
                    bulletEffect.transform.position = hitInfo.point;
                    bulletEffect.transform.forward = hitInfo.normal;

                    ps.Play();
                }

            }
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            switch (wMode)
            {
                case WeaponMode.Normal:
                    GameObject bomb = Instantiate(bombFactory);
                    bomb.transform.position = firePosition.transform.position;

                    Rigidbody rb = bomb.GetComponent<Rigidbody>();
                    rb.AddForce((Camera.main.transform.forward + Camera.main.transform.up * 0.5f) * throwPower, ForceMode.Impulse);
                    break;
                
                case WeaponMode.Sniper: // 저격 모드일 때 마우스 오른쪽 -> 확대/축소 조준경
                    //if (!zoomMode)
                    //{
                    //    Camera.main.fieldOfView = 15f;
                    //    zoomMode = true;
                    //}
                    //else
                    //{
                    //    Camera.main.fieldOfView = 60f;
                    //    zoomMode = false;
                    //}
                    float fov = zoomMode ? 60f : 15f;
                    Camera.main.fieldOfView = fov;
                    zoomMode = !zoomMode;
                    break;
            }
            

            
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            wMode = WeaponMode.Normal;
            Camera.main.fieldOfView = 60f;
            wModeText.text = "Normal Mode";

            weapon01.SetActive(true);
            weapon02.SetActive(false);
            crossHair01.SetActive(true);
            crossHair02.SetActive(false);
            weapon01_R.SetActive(true);
            weapon02_R.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            wMode = WeaponMode.Sniper;
            wModeText.text = "Sniper Mode";

            weapon01.SetActive(false);
            weapon02.SetActive(true);
            crossHair01.SetActive(false);
            crossHair02.SetActive(true);
            weapon01_R.SetActive(false);
            weapon02_R.SetActive(true);
        }
    }
    IEnumerator ShootEffectOn(float duration)
    {
        int num = Random.Range(0, eff_Flash.Length);

        eff_Flash[num].SetActive(true);

        yield return new WaitForSeconds(duration);
        eff_Flash[num].SetActive(false);
    }
}
