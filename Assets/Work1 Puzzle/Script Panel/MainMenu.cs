using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Select;
    
    public void SelectLevelToPlay()
    {
        Menu.SetActive(false);
        Select.SetActive(true);
        SelectLevel.Instance.SetAllToFalse();
    }

    public void Quit()
    {
        Application.Quit();
    }
}