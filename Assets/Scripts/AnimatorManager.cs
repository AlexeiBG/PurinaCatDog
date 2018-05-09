using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour {

    [Header("Both Screens GameObjects")]
    public GameObject firstScreen;
    public GameObject secondScreen;
    public float timeToChange = 5f;

    [Header("Animators")]
    public GameObject popPanelOrganos;
    public GameObject Screens;
    Animator anim;
    Animator screenAnim;

    Manager man;

    private void Start()
    {
        man = FindObjectOfType<Manager>();
        anim = popPanelOrganos.GetComponent<Animator>();
        screenAnim = Screens.GetComponent<Animator>();
    }

    //Function to handle PopUps of the organs
    public void PopOrganPanel()
    {
        anim.SetTrigger("Pop");
    }

    public void HideOrganPanel()
    {
        anim.SetTrigger("Hide");
    }

    public void ChangeScreens()
    {
        //hide the organpanel
        //man.QuitPanel();
        //switch screens
        //firstScreen.SetActive(false);
        //secondScreen.SetActive(true);

        //TRIGGERS animator to switch screen
        //trigger second screen appear
        StartCoroutine(changeScreens());
    }

    public void returnToAnimal()
    {
        //switch screens
        firstScreen.SetActive(true);
        secondScreen.SetActive(false);
        screenAnim.SetTrigger("returnAnimalScreen");
        StartCoroutine(waitForIdle());

        //return to normal scale
        man.changeScaleOfButtonSmall();
        man.enableOtherButtons();

        man.ReGlow();
    }
    
    IEnumerator waitForIdle()
    {
        yield return new WaitForSeconds(1f);
        screenAnim.SetTrigger("idle");
    }

    IEnumerator changeScreens()
    {
        yield return new WaitForSeconds(timeToChange);
        screenAnim.SetTrigger("SecondCall");
        man.QuitPanel();
    }

}
