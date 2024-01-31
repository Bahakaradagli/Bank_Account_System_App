using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Close : MonoBehaviour
{

    [SerializeField] public GameObject AreYouSure;
    [SerializeField] public GameObject AppManager;


    AppManager appManager;

    private void Start()
    {
        AppManager = GameObject.Find("AppManager");
    }
    public void Close_Screen_Yes()
    {
        int Gider_List_Count = PlayerPrefs.GetInt("HowManyGider");
        int Gelir_List_Count = PlayerPrefs.GetInt("HowManyGelir");
        Debug.Log("Hello");

        if (AppManager.GetComponent<AppManager>().Gider_Panel.activeSelf)
        {
            for (int i = 0; i < Gider_List_Count; i++)
            {
                //Debug.Log((gameObject.transform.parent.gameObject.GetComponent<GiderInfo>().Tittle.text).ToString());
                //Debug.Log(PlayerPrefs.GetString("Title" + i));
                if ((gameObject.transform.parent.gameObject.GetComponent<GiderInfo>().Tittle.text).ToString() == PlayerPrefs.GetString("Title" + i))
                {
                    PlayerPrefs.SetInt("HowMuchGider", PlayerPrefs.GetInt("HowMuchGider") - PlayerPrefs.GetInt("Amount" + i));

                    Debug.Log("Helloo");
                    PlayerPrefs.SetString("Title" + i, "");
                    PlayerPrefs.SetString("Description" + i, "");
                    PlayerPrefs.SetInt("Amount" + i, 0);
                    PlayerPrefs.SetString("Date" + i, "");
                    int temp = i;
                    for (int j = i + 1; j < Gider_List_Count; j++)
                    {
                        PlayerPrefs.SetString("Title" + temp, PlayerPrefs.GetString("Title" + j));
                        PlayerPrefs.SetString("Description" + temp, PlayerPrefs.GetString("Description" + j));
                        PlayerPrefs.SetInt("Amount" + temp, PlayerPrefs.GetInt("Amount" + j));
                        PlayerPrefs.SetString("Date" + temp, PlayerPrefs.GetString("Date" + j));
                        temp++;
                    }
                    Gider_List_Count -= 1;
                    PlayerPrefs.SetInt("HowManyGider", Gider_List_Count);
               
                    Debug.Log(i);

                    AppManager.GetComponent<AppManager>().Gider_List.RemoveAt(i);
                    AppManager.GetComponent<AppManager>().Gameobject_Gider_List.RemoveAt(i);

                    Debug.Log(PlayerPrefs.GetInt("HowMuchGelir"));
                    Destroy(gameObject.transform.parent.gameObject);

                    //break;
                }


            }
        }
        if (AppManager.GetComponent<AppManager>().Gelir_Panel.activeSelf)
        {
            for (int i = 0; i < Gelir_List_Count; i++)
            {
                //Debug.Log((gameObject.transform.parent.gameObject.GetComponent<GiderInfo>().Tittle.text).ToString());
                //Debug.Log(PlayerPrefs.GetString("Title" + i));
                if ((gameObject.transform.parent.gameObject.GetComponent<GiderInfo>().Tittle.text).ToString() == PlayerPrefs.GetString("Gelir_Title" + i))
                {
                    PlayerPrefs.SetInt("HowMuchGelir", PlayerPrefs.GetInt("HowMuchGelir") - PlayerPrefs.GetInt("Gelir_Amount" + i));

                    Debug.Log("Helloo");
                    PlayerPrefs.SetString("Gelir_Title" + i, "");
                    PlayerPrefs.SetString("Gelir_Description" + i, "");
                    PlayerPrefs.SetInt("Gelir_Amount" + i, 0);
                    PlayerPrefs.SetString("Gelir_Date" + i, "");

                    int temp = i;
                    for (int j = i + 1; j < Gelir_List_Count; j++)
                    {
                        PlayerPrefs.SetString("Gelir_Title" + temp, PlayerPrefs.GetString("Gelir_Title" + j));
                        PlayerPrefs.SetString("Gelir_Description" + temp, PlayerPrefs.GetString("Gelir_Description" + j));
                        PlayerPrefs.SetInt("Gelir_Amount" + temp, PlayerPrefs.GetInt("Gelir_Amount" + j));
                        PlayerPrefs.SetString("Gelir_Date" + temp, PlayerPrefs.GetString("Gelir_Date" + j));
                        temp++;
                    }
                    Gelir_List_Count -= 1;
                    PlayerPrefs.SetInt("HowManyGelir", Gelir_List_Count);
                   

                    Debug.Log(i);

                    AppManager.GetComponent<AppManager>().Gelir_List.RemoveAt(i);
                    AppManager.GetComponent<AppManager>().Gameobject_Gelir_List.RemoveAt(i);

                    Debug.Log("HowMuchGelir"+PlayerPrefs.GetInt("HowMuchGelir"));
                    Debug.Log("GelirAmount"+PlayerPrefs.GetInt("Gelir_Amount" + i));
                    Destroy(gameObject.transform.parent.gameObject);

                    //break;
                }


            }
        }
    }

    public void Close_Screen_No()
    {
        AreYouSure.SetActive(false);
    }

    public void Close_Screen()
    {
        AreYouSure.SetActive(true);
    }


}
