using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AppManager : MonoBehaviour
{

    public static AppManager instance;

    [Header("Tavsiyeler")]
    [SerializeField] private TMP_Text Tavsiye1;



    [Header("Panels")]
    [SerializeField] public GameObject Gider_Panel;
    [SerializeField] public GameObject Gelir_Panel;
    [SerializeField] private GameObject Istenen_Kar_Panel;
    [SerializeField] private GameObject Gider_Input_Panel;
    [SerializeField] private GameObject Gelir_Input_Panel;
    [SerializeField] private GameObject Istenen_Kar_Input_Panel;
    [SerializeField] private GameObject Home_Panel;

    [Header("IstenenKarTexts")]
    [SerializeField] public TMP_Text ÝstenenKar_Harcamalar_Text;
    [SerializeField] public TMP_Text ÝstenenKar_ÝstenenKar_Text;
    [SerializeField] public TMP_Text ÝstenenKar_Gelir_Text;
    [SerializeField] public TMP_Text ÝstenenKar_GerekenGelir_Text;


    [Header("ObjectSpawn")]
    [SerializeField] private GameObject Gider_Card;
    [SerializeField] private GameObject Gider_Box;
    [SerializeField] private GameObject Gelir_Card;
    [SerializeField] private GameObject Gelir_Box;

    [Header("Inputs")]
    [SerializeField] private TMP_InputField Gider_Title_Input;
    [SerializeField] private TMP_InputField Gelir_Title_Input;
    [SerializeField] private TMP_InputField Gider_Decription_Input;
    [SerializeField] private TMP_InputField Gelir_Decription_Input;
    [SerializeField] private TMP_InputField Gider_Amount_Input;
    [SerializeField] private TMP_InputField Gelir_Amount_Input;
    [SerializeField] private TMP_InputField Istenen_Kar_Amount_Input;
    [SerializeField] private TMP_InputField Gider_Date_Input;
    [SerializeField] private TMP_InputField Gelir_Date_Input;

    [Header("Selections")]
    [SerializeField] private TMP_Text Gider_Select_Text;
    [SerializeField] private TMP_Text Gelir_Select_Text;
    [SerializeField] private TMP_Text Istenen_Kar_Select_Text;
    [SerializeField] private GameObject Home_Select;

    [Header("Dont Know")]
    [SerializeField] private TMP_Text Gider_Decription_Text;
    [SerializeField] private TMP_Text Gelir_Decription_Text;
    [SerializeField] private TMP_Text Gider_Amount_Text;
    [SerializeField] private TMP_Text Gelir_Amount_Text;
    [SerializeField] private TMP_Text Gider_Date_Text;
    [SerializeField] private TMP_Text Gelir_Date_Text;

    [Header("Lists")]
    [SerializeField] public int All_Gider;
    [SerializeField] public int All_Gelir;
    [SerializeField] public List<int> Gider_List = new List<int>();
    [SerializeField] public List<int> Gelir_List = new List<int>();
    [SerializeField] public List<GameObject> Gameobject_Gider_List = new List<GameObject>();
    [SerializeField] public List<GameObject> Gameobject_Gelir_List = new List<GameObject>();


    private void Start()
    {
        PlayerPrefs.SetInt("HowMuchGelir",0);
        PlayerPrefs.SetInt("HowMuchGider",0);
        Gelir_Panel_Open();

        for(int i = 0;i< PlayerPrefs.GetInt("HowManyGider");i++)
        {
            PlayerPrefs.GetInt("Amount" + i);
            PlayerPrefs.SetInt("HowMuchGider", PlayerPrefs.GetInt("HowMuchGider") + PlayerPrefs.GetInt("Amount" + i));
            Gider_Ekle();
            
        }

        for (int i = 0; i < PlayerPrefs.GetInt("HowManyGelir"); i++)
        {
            PlayerPrefs.GetInt("Gelir_Amount" + i);
            PlayerPrefs.SetInt("HowMuchGelir", PlayerPrefs.GetInt("HowMuchGelir") + PlayerPrefs.GetInt("Gelir_Amount" + i));
            Gelir_Ekle();

        }



    }
    private void FixedUpdate()
    {



        Tavsiye1.text = "Hesaplamalarýma göre harcamalarýn " + PlayerPrefs.GetInt("All_Gider") + "TL kadar ve bana eklediðin ürünlere uygun fiyatlar ekleyerek " + PlayerPrefs.GetInt("Ýstenen_Kar") + "TL kadar bir kara ulaþabiliriz. ";
        ÝstenenKar_GerekenGelir_Text.text = ((PlayerPrefs.GetInt("HowMuchGider") + PlayerPrefs.GetInt("Istenen_Kar"))-PlayerPrefs.GetInt("HowMuchGelir")).ToString();
        ÝstenenKar_ÝstenenKar_Text.text = (PlayerPrefs.GetInt("Istenen_Kar")).ToString();
        ÝstenenKar_Harcamalar_Text.text = (PlayerPrefs.GetInt("HowMuchGider")).ToString();
        ÝstenenKar_Gelir_Text.text = (PlayerPrefs.GetInt("HowMuchGelir")).ToString();
    }

    private void Gider_Sum(int Sum_Of_Gider)
    {

        if(Gider_Panel.activeSelf)
        {
            Sum_Of_Gider = 0;
            for (int i = 0; i < Gider_List.Count; i++)
            {
                Debug.Log(PlayerPrefs.GetInt("Amount" + i));
                Sum_Of_Gider += PlayerPrefs.GetInt("Amount" + i);
            }
            Debug.Log("SumOf" + Sum_Of_Gider);
            PlayerPrefs.SetInt("HowMuchGider", Sum_Of_Gider);
        }
      
      
        
        
        if (Gelir_Panel.activeSelf)
        {
            Sum_Of_Gider = 0;
            for (int i = 0; i < Gelir_List.Count; i++)
            {
                Debug.Log(PlayerPrefs.GetInt("Gelir_Amount" + i));
                Sum_Of_Gider += PlayerPrefs.GetInt("Gelir_Amount" + i);
            }
            Debug.Log("SumOf" + Sum_Of_Gider);
            PlayerPrefs.SetInt("HowMuchGelir", Sum_Of_Gider);
        }
            
    }

    //buttons

    public void Gider_Ekle()
    {
        if (Gider_List.Count == PlayerPrefs.GetInt("HowManyGider"))
        {
            System.DateTime currentTime = System.DateTime.Now;
            int Amount_Gider = int.Parse(Gider_Amount_Input.text.ToString());
            PlayerPrefs.SetInt("Amount"+Gider_List.Count, Amount_Gider);

            string Decription_Gider = Gider_Decription_Input.text.ToString();
            PlayerPrefs.SetString("Description"+Gider_List.Count, Decription_Gider);

            string Title_Gider = Gider_Title_Input.text.ToString();
            PlayerPrefs.SetString("Title" + Gider_List.Count, Title_Gider);

            string Date_Gider = currentTime.ToString();
            PlayerPrefs.SetString("Date" + Gider_List.Count, Date_Gider);

            GiderInfo _GiI = Instantiate(Gider_Card, Gider_Box.transform).GetComponent<GiderInfo>();
            _GiI.Tittle.text = Title_Gider;
            _GiI.Description.text = Decription_Gider;
            _GiI.Date.text = Date_Gider;

            if (Amount_Gider <= 0)
            {
                _GiI.Amount.text = Amount_Gider.ToString();
                Gider_List.Add(Amount_Gider);
            }
            if (Amount_Gider >= 0)
            {
                _GiI.Amount.text = (-Amount_Gider).ToString();
                Gider_List.Add(-Amount_Gider);
            }

            PlayerPrefs.SetInt("HowManyGider", Gider_List.Count);
        }

         if(Gider_List.Count < PlayerPrefs.GetInt("HowManyGider"))
         {
            int Amount_Gider_DATA = PlayerPrefs.GetInt("Amount"+Gider_List.Count);
            string Decription_DATA = PlayerPrefs.GetString("Description" + Gider_List.Count);
            string Title_DATA = PlayerPrefs.GetString("Title" + Gider_List.Count);
            string Date_DATA = PlayerPrefs.GetString("Date" + Gider_List.Count);

            GiderInfo _GiI_DATA = Instantiate(Gider_Card, Gider_Box.transform).GetComponent<GiderInfo>();
            _GiI_DATA.Tittle.text = Title_DATA;
            _GiI_DATA.Description.text = Decription_DATA;
            _GiI_DATA.Date.text = Date_DATA;

            if (Amount_Gider_DATA <= 0)
            {
                _GiI_DATA.Amount.text = Amount_Gider_DATA.ToString();
                Gider_List.Add(Amount_Gider_DATA);
            }
            if (Amount_Gider_DATA >= 0)
            {
                _GiI_DATA.Amount.text = (-Amount_Gider_DATA).ToString();
                Gider_List.Add(-Amount_Gider_DATA);
            }

         }

      
     

        Gameobject_Gider_List.Add(Gider_Card);
        Gider_Sum(All_Gider);


        



        Gider_Title_Input.text = "";
        Gider_Decription_Input.text = "";
        Gider_Amount_Input.text = "";
    }
    public void Gelir_Ekle()
    {
        if (Gelir_List.Count == PlayerPrefs.GetInt("HowManyGelir"))
        {
            System.DateTime currentTime = System.DateTime.Now;
            int Amount_Gelir = int.Parse(Gelir_Amount_Input.text.ToString());
            PlayerPrefs.SetInt("Gelir_Amount" + Gelir_List.Count, Amount_Gelir);

            string Decription_Gelir = Gelir_Decription_Input.text.ToString();
            PlayerPrefs.SetString("Gelir_Description" + Gelir_List.Count, Decription_Gelir);

            string Title_Gelir = Gelir_Title_Input.text.ToString();
            PlayerPrefs.SetString("Gelir_Title" + Gelir_List.Count, Title_Gelir);

            string Date_Gelir = currentTime.ToString();
            PlayerPrefs.SetString("Gelir_Date" + Gelir_List.Count, Date_Gelir);

            GiderInfo _GeI = Instantiate(Gelir_Card, Gelir_Box.transform).GetComponent<GiderInfo>();
            _GeI.Tittle.text = Title_Gelir;
            _GeI.Description.text = Decription_Gelir;
            _GeI.Date.text = Date_Gelir;

            if (Amount_Gelir >= 0)
            {
                _GeI.Amount.text = Amount_Gelir.ToString();
                Gelir_List.Add(Amount_Gelir);
            }
            if (Amount_Gelir <= 0)
            {
                _GeI.Amount.text = (-Amount_Gelir).ToString();
                Gelir_List.Add(-Amount_Gelir);
            }

            PlayerPrefs.SetInt("HowManyGelir", Gelir_List.Count);
        }

        if (Gelir_List.Count < PlayerPrefs.GetInt("HowManyGelir"))
        {
            int Amount_Gelir_DATA = PlayerPrefs.GetInt("Gelir_Amount" + Gelir_List.Count);
            string Decription_DATA = PlayerPrefs.GetString("Gelir_Description" + Gelir_List.Count);
            string Title_DATA = PlayerPrefs.GetString("Gelir_Title" + Gelir_List.Count);
            string Date_DATA = PlayerPrefs.GetString("Gelir_Date" + Gelir_List.Count);

            GiderInfo _GeI_DATA = Instantiate(Gelir_Card, Gelir_Box.transform).GetComponent<GiderInfo>();
            _GeI_DATA.Tittle.text = Title_DATA;
            _GeI_DATA.Description.text = Decription_DATA;
            _GeI_DATA.Date.text = Date_DATA;

            if (Amount_Gelir_DATA <= 0)
            {
                _GeI_DATA.Amount.text = Amount_Gelir_DATA.ToString();
                Gelir_List.Add(Amount_Gelir_DATA);
            }
            if (Amount_Gelir_DATA >= 0)
            {
                _GeI_DATA.Amount.text = (-Amount_Gelir_DATA).ToString();
                Gelir_List.Add(-Amount_Gelir_DATA);
            }

        }




        Gameobject_Gelir_List.Add(Gelir_Card);
        Gider_Sum(All_Gelir);



        Debug.Log(All_Gelir);


        Gelir_Title_Input.text = "";
        Gelir_Decription_Input.text = "";
        Gelir_Amount_Input.text = "";
    }

    public void Istenen_Kar_Ekle()
    {
        PlayerPrefs.SetInt("Istenen_Kar",int.Parse(Istenen_Kar_Amount_Input.text.ToString()));
        Debug.Log("Istenen Kar Artýk: " + PlayerPrefs.GetInt("Istenen_Kar"));
    }


    public void Gider_Panel_Open()
    {
        Gider_Select_Text.color = new Color32(255, 255, 255, 255);
        Gelir_Select_Text.color = new Color32(255, 255, 255, 145);
        Istenen_Kar_Select_Text.color = new Color32(255, 255, 255, 145);
        Gider_Panel.SetActive(true);
        Gider_Input_Panel.SetActive(true);
        Gelir_Panel.SetActive(false);
        Gelir_Input_Panel.SetActive(false);
        Istenen_Kar_Panel.SetActive(false);
        Istenen_Kar_Input_Panel.SetActive(false);
    }
    public void Gelir_Panel_Open()
    {
        Gelir_Select_Text.color = new Color32(255, 255, 255, 255);
        Gider_Select_Text.color = new Color32(255, 255, 255, 145);
        Istenen_Kar_Select_Text.color = new Color32(255, 255, 255, 145);
        Gelir_Panel.SetActive(true);
        Gelir_Input_Panel.SetActive(true);
        Gider_Panel.SetActive(false);
        Gider_Input_Panel.SetActive(false);
        Istenen_Kar_Panel.SetActive(false);
        Istenen_Kar_Input_Panel.SetActive(false);
    }

    public void Istenen_Kar_Panel_Open()
    {
        Gelir_Select_Text.color = new Color32(255, 255, 255, 145);
        Gider_Select_Text.color = new Color32(255, 255, 255, 145);
        Istenen_Kar_Select_Text.color = new Color32(255, 255, 255, 255);
        Istenen_Kar_Panel.SetActive(true);
        Istenen_Kar_Input_Panel.SetActive(true);
        Gider_Panel.SetActive(false);
        Gider_Input_Panel.SetActive(false);
        Gelir_Panel.SetActive(false);
        Gelir_Input_Panel.SetActive(false);
    }

    public void Home_Open()
    {
        Home_Panel.SetActive(true);
    }



}
