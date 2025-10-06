using UnityEngine;
using UnityEngine.InputSystem;

public class CollectTest : MonoBehaviour
{

    public Animator animator;
    public bool isDefending = false;
    public bool canPunch = true;

    public bool withAxe = false;

    public GameObject Axe;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Axe.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //Equipa o item da tecla 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            withAxe = false;
            canPunch = true;

            Axe.SetActive(false);
            if (!withAxe)
            {
                animator.SetBool("IsHolding", false);
            }
        }

        //Equipa o item da tecla 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            withAxe = true;
            canPunch = false;

            Axe.SetActive(true);
            if (withAxe)
            {
                animator.SetBool("IsHolding", true);
            }
        }

        //Ataque com o machado com o bot�o esquerdo do Mouse

        if (withAxe && Input.GetMouseButtonDown(0)) // aperta o bot�o
        {
            animator.SetTrigger("IsSlashing");
            //if (axeTriggerCollider != null)
            //{
            //    axeTriggerCollider.enabled = true;  // Ativa o Trigger
            //}
        }

        //if (Input.GetMouseButtonUp(0))  // Solta o bot�o
        //{
        //    if (axeTriggerCollider != null)
        //    {
        //        axeTriggerCollider.enabled = false;  // Desativa o Trigger
        //    }
        //}



        //Coleta o item com tecla E
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("IsCollecting");
        }

        //Ataque com o bot�o esquerdo do Mouse
        if (Input.GetMouseButtonDown(0) && canPunch)
        {
            animator.SetTrigger("IsPunching");
        }

        //Defesa com bot�o direito do Mouse:

            //Com machado
        if (withAxe && Input.GetMouseButton(1))
        {
            if (!isDefending)
            {
                StartDefending();
            }
            else
            {
                StopDefending();
            }
        }

            //Desarmado
        if (Input.GetMouseButton(1))
        {
            if (!isDefending)
            {
                StartDefending();
            }
        }
        else
        {
            if(isDefending)
            {
                StopDefending();
            }
        }
    }

    void StartDefending()
    {
        isDefending = true;
        animator.SetBool("IsWatch",true);
        Debug.Log("Defendendo!");
        // Aqui voc� pode ativar anima��o, reduzir dano, etc.
    }

    void StopDefending()
    {
        isDefending = false;
        animator.SetBool("IsWatch", false);
        Debug.Log("Parou de defender!");
        // Aqui voc� pode desativar a anima��o, voltar � posi��o normal, etc.
    }
}
