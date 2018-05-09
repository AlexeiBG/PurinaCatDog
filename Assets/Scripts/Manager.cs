using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    [Header("Elementos de organos")]
    public GameObject panelOrgano;
    [SerializeField]
    private TMP_Text tituloOrgano;
    [SerializeField]
    private TMP_Text padecimientos;
    [SerializeField]
    private Image line;
    [SerializeField]
    private Image OrganImage;

   
    [Header("Sprites de organos")]
    [SerializeField]
    private Sprite LiverSprite;
    [SerializeField]
    private Sprite KidneySprite;
    [SerializeField]
    private Sprite HeartSprite;
    [SerializeField]
    private Sprite IntestinesSprite;
    [SerializeField]
    private Sprite BladderSprite;

    [Header("Textos de paneles")]
    [TextArea]
    public string HigadoPadecimientos;
    [TextArea]
    public string KidneyPadecimientos;
    [TextArea]
    public string BladderPadecimientos;
    [TextArea]
    public string HeartPadecimientos;
    [TextArea]
    public string IntestinesPadecimientos;

    [Header("Colores de organos")]
    public Color higadoColor;
    public Color RiñonColor;
    public Color CorazonColor;
    public Color intestColor;
    public Color bladdColor;

    [Header("Elementos 2 panel")]
    public GameObject SegundoPanel;
    public GameObject panelSuperior;
    public Image imagenProducto;
    public TMP_Text TituloProducto;

    [Header("Product Logo Array")]
    public Sprite[] ProductLogo;

    [Header("Products Sprites Array")]
    public Sprite[] productsSprites;

    [Header("Animator")]
    public AnimatorManager sS;

    [Header("SeconD Screen Stuff")]
    [SerializeField]
    private GameObject S2panelSuperior;
    [SerializeField]
    private Image S2productImageBanner;
    [SerializeField]
    private TMP_Text S2tituloProducto;
    [SerializeField]
    private Image S2padecimientos;
    [SerializeField]
    private Image S2ProductoImage;
    [SerializeField]
    private TMP_Text BeneficiosClaves;

    [Header("Buttons")]
    public GameObject[] buttons;
    public GameObject centerObj;
    public Color glowColor;
    public float alpha = .01f;

    private void Start()
    {
        panelOrgano.SetActive(false);
        sS = GetComponent<AnimatorManager>();
       
    }

	public void LateUpdate (){

        Glow();
       
	}

    public void Glow(){
        alpha = alpha + 0.05f;

        foreach (GameObject gb in buttons)
        {
            //Debug.Log(gb.transform.GetChild(0).name );
            if (alpha >= 1f)
            {
                alpha = .01f;
            }
            else
            {
                glowColor.a += alpha;
                gb.transform.GetChild(0).GetComponent<Image>().color = new Color(glowColor.r, glowColor.g, glowColor.b, alpha);
            }
        }

    }

    public void ReGlow(){
        foreach (GameObject gb in buttons)
        {
            gb.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void UnGlow(){
        foreach (GameObject gb in buttons)
        {
            gb.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

	//hides the organpanel, show in animation then deactivates it 
	public void QuitPanel()
    {
        panelOrgano.SetActive(false);
        sS.HideOrganPanel();
        // ContinueTimer();
    }
    
    //[0]
	public void showLiver()
    {
        //stop glowing
        UnGlow();

        Debug.Log("click liver");
        //change scale of button
        changeScaleOfButtonBig(buttons[0]);
        //make transparent to other buttons
        disableOtherButtons("Liver");

        changePanelValues("Higado", HigadoPadecimientos, higadoColor, LiverSprite);
       // buttons[0].GetComponent<Transform>().localScale(new Vector3(1.5f, 1.5f, 1.5f), 1);
        sS.PopOrganPanel();
        //this one might repeat with other organs depending the assoc
        ChangeValuesSecondScreen(higadoColor, productsSprites[0], "Manejo nutricional para el Higado", ProductLogo[0] );
        //calls animator manager to handle time to change 2 second screen
        sS.ChangeScreens();
        //get the canvas component of the button and throw animation
    }

    //[1]
    public void showKidney()
    {
        //stop glowing
        UnGlow();

        Debug.Log("click Kidney");
        //change scale of button
        changeScaleOfButtonBig(buttons[1]);
        //make transparent to other buttons
        disableOtherButtons("Kidney");

        changePanelValues("Riñon", KidneyPadecimientos, RiñonColor, KidneySprite);
        sS.PopOrganPanel();
        //this one might repeat with other organs depending the assoc
        ChangeValuesSecondScreen(RiñonColor, productsSprites[1], "Manejo nutricional para el Riñon", ProductLogo[1]);
        //calls animator manager to handle time to change 2 second screen
        sS.ChangeScreens();

    }

    //[2]
    public void showBladder()
    {
        //stop glowing
        UnGlow();

        Debug.Log("click Bladder");
        //change scale of button
        changeScaleOfButtonBig(buttons[2]);
        //make transparent to other buttons
        disableOtherButtons("Bladder");

        changePanelValues("Vejiga", BladderPadecimientos, bladdColor, BladderSprite);
        sS.PopOrganPanel();
        //this one might repeat with other organs depending the assoc
        ChangeValuesSecondScreen( bladdColor , productsSprites[2], "Manejo nutricional para la Vejiga", ProductLogo[2]);
        //calls animator manager to handle time to change 2 second screen
        sS.ChangeScreens();
    }

    //[3]
    public void showIntestines()
    {
        //stop glowing
        UnGlow();

        Debug.Log("click Intest");
        //change scale of button
        changeScaleOfButtonBig(buttons[3]);
        //make transparent to other buttons
        disableOtherButtons("Intestines");

        changePanelValues("Intestinos", IntestinesPadecimientos, intestColor, IntestinesSprite);
        sS.PopOrganPanel();
        //this one might repeat with other organs depending the assoc
        ChangeValuesSecondScreen(intestColor, productsSprites[3], "Manejo nutricional para intestinos", ProductLogo[3]);
        //calls animator manager to handle time to change 2 second screen
        sS.ChangeScreens();
    }

    //[4]
    public void showHeart()
    {
        //stop glowing
        UnGlow();

        Debug.Log("click Heart");
        //change scale of button
        changeScaleOfButtonBig(buttons[4]);
        //make transparent to other buttons
        disableOtherButtons("Corazon");

        changePanelValues("Corazón", HeartPadecimientos, CorazonColor, HeartSprite);
        sS.PopOrganPanel();
        //this one might repeat with other organs depending the assoc
        ChangeValuesSecondScreen( CorazonColor, productsSprites[4], "Manejo nutricional para el Corazon", ProductLogo[4]);
        //calls animator manager to handle time to change 2 second screen
        sS.ChangeScreens();
    }

    //Organ panel values
    private void changePanelValues(string organtext, string padecimientostext, Color colorOrgan, Sprite organsprite)
    {
        tituloOrgano.text = organtext;
        tituloOrgano.faceColor = new Color(colorOrgan.r, colorOrgan.g, colorOrgan.b, 1);
        padecimientos.text = padecimientostext;
        padecimientos.faceColor = new Color(colorOrgan.r, colorOrgan.g, colorOrgan.b, 1);
        line.GetComponent<Image>().color = new Color( colorOrgan.r, colorOrgan.g, colorOrgan.b,1 );
        //panelOrgano.SetActive(true);
        OrganImage.sprite = organsprite;
    }

    //Second screen panel values
    private void ChangeValuesSecondScreen(Color colorOrgan, Sprite productLogo, string TituloProducto, Sprite productSprites)
    {
        
        //change all the images and colors in second screen accordingly to the organ
        S2panelSuperior.GetComponent<Image>().color= new Color(colorOrgan.r, colorOrgan.g, colorOrgan.b, 1);
        S2productImageBanner.sprite = productLogo;
        S2tituloProducto.text = TituloProducto;
        S2ProductoImage.sprite = productSprites;
        BeneficiosClaves.faceColor = new Color(colorOrgan.r, colorOrgan.g, colorOrgan.b, 1);

    }

    private void changeScaleOfButtonBig(GameObject b)
    {
       StartCoroutine(changeScaleOfButtonBig_Corout(b));
    }

    IEnumerator changeScaleOfButtonBig_Corout(GameObject b)
    {
        b.transform.localScale = new Vector3(.5f, .5f, .5f);
        /*        float elapsedTime = 0.0f;

                Vector3 start = b.transform.position;
                Vector3 end = new Vector3(-1.6f, 10f, 0f);
                float duration = 1f;

                while (b.transform.position != end)
                {
                    elapsedTime += Time.deltaTime;
                    transform.position = Vector3.Lerp(start, end, elapsedTime / duration);
                    yield return null;
                }
        */

        b.transform.position = Vector3.MoveTowards(b.transform.position, centerObj.transform.position, Time.deltaTime);
        yield return null;
    }

    public void changeScaleOfButtonSmall()
    {
        foreach (GameObject gb in buttons)
        {
            
            gb.transform.localScale = new Vector3(0.1321171f, 0.1321171f, 0.1321171f);
        }
       
    }

    public void disableOtherButtons(string organ)
    {

        //leave one alive
        /*
        foreach (GameObject b in buttons)
        {
            if (b.name != organ)
            {
                b.GetComponent<Image>().raycastTarget = false;
                b.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.1f);
            }
            
        }
        */
        //kill them all
        foreach (GameObject b in buttons)
        {
            b.GetComponent<Image>().raycastTarget = false;
            if (b.name != organ)
            {
                b.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.05f);
            }
        }
    }

    public void enableOtherButtons()
    {
        foreach (GameObject b in buttons)
        {
            b.GetComponent<Image>().raycastTarget = true;
            b.GetComponent<Image>().color = new Color(255f, 255f, 255f, 1f);
        }
    }
    
    //wait for it, then change the screen
    private void Timer2SecondScreen()
    {
        //timer and then animation
    }

    //function to stop time
    private void StopTimer()
    {
        Time.timeScale = 0;
    }

    // continue timer
    private void ContinueTimer()
    {
        Time.timeScale = 1;
    }
}
