using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShell_logic : MonoBehaviour
{

    [SerializeField] private GameObject Shell;
    [SerializeField] private MeshRenderer ShellRender;
    [SerializeField] private GameObject ExplotionAnimation;
    [SerializeField] private Rigidbody Rigidbody;
    [SerializeField] private float explotionForce;
    [SerializeField] private float explotionRadius;
    [SerializeField] private float explotionTimerAnimation;
    [SerializeField] private Enemy_Shoot enemyShootlogic;

    private float explotionTime = 0;
    private bool animationRun;

    private void Start()
    {
        animationRun = false;
        ExplotionAnimation.SetActive(false);
        ShellRender = GetComponentInChildren<MeshRenderer>();
    }

    private void Update()
    {
        if (animationRun)
        {
            explotionTime += Time.deltaTime;
        }

        if (explotionTimerAnimation < explotionTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] entitys = Physics.OverlapSphere(transform.position, explotionRadius);

        foreach (Collider collider in entitys)
        {
            Rigidbody EntRB = collider.GetComponent<Rigidbody>();

            if (EntRB != null)
            {
                EntRB.AddExplosionForce(explotionForce, transform.position, explotionRadius);

                ExplotionAnimation.SetActive(true);
                animationRun = true;

                Player_Health player = EntRB.GetComponent<Player_Health>();
                if (player != null)
                {
                    player.GetDamage(enemyShootlogic.GetDamage());
                    Shell.GetComponent<CapsuleCollider>().enabled = false;
                }

                Health_Rocks rock = EntRB.GetComponent<Health_Rocks>();
                if (rock != null)
                {
                    rock.GetDamage(enemyShootlogic.GetDamage());
                    Shell.GetComponent<CapsuleCollider>().enabled = false;
                }

                ShellRender.enabled = false;

            }

        }
    }

}

