using UnityEngine;

public class SelectLevel : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Select;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;

    public static SelectLevel Instance;

    void Awake()
    {
        Instance = this;
    }
    
    public void LoadMenu()
    {
        Menu.SetActive(true);
        Select.SetActive(false);
        SetAllToFalse();
        Level1Check.Instance.Reset();
        Level2Check.Instance.Reset();
        Level3Check.Instance.Reset();
    }

    public void LoadLevel1()
    {
        Menu.SetActive(false);
        Select.SetActive(false);
        Level1.SetActive(true);

        DisableScript();
        Level1Check level1 = GetComponent<Level1Check>();
        level1.enabled = true;
    }
    
    public void LoadLevel2()
    {
        Menu.SetActive(false);
        Select.SetActive(false);
        Level2.SetActive(true);
        
        DisableScript();
        Level2Check level2 = GetComponent<Level2Check>();
        level2.enabled = true;
    }
    
    public void LoadLevel3()
    {
        Menu.SetActive(false);
        Select.SetActive(false);
        Level3.SetActive(true);
        
        DisableScript();
        Level3Check level3 = GetComponent<Level3Check>();
        level3.enabled = true;
    }

    public void SetAllToFalse()
    {
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(false);
    }

    public void DisableScript()
    {
        Level1Check level1 = GetComponent<Level1Check>();
        Level2Check level2 = GetComponent<Level2Check>();
        Level3Check level3 = GetComponent<Level3Check>();

        level1.enabled = false;
        level2.enabled = false;
        level3.enabled = false;
    }
}