using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager = null;

    GameObject currentOpenWindow;

    [SerializeField]
    GameObject[] canvasWindows = null;

    [SerializeField]
    Text[] oresValues = null;
    [SerializeField]
    Text[] alloysValues = null;


    float timer;

    public void ConfirmExitWindowExitButton()
    {
        Application.Quit();
    }

    public void OresWindowOpen(GameObject window)
    {
        if (currentOpenWindow)
            currentOpenWindow.SetActive(false);

        window.SetActive(true);
        currentOpenWindow = window;
        timer = 1.0f;
    }
    public void OresWindowClose()
    {
        
    }

    public void OresWindowUpgrade(int oreNumber)
    {
        switch (oreNumber)
        {
            case ((int)Ores.Copper):
                if (gameManager.alloys[0] == 0)
                    return;
                gameManager.alloys[0]--;
                break;
            case ((int)Ores.Iron):
                if (gameManager.alloys[1] == 0)
                    return;
                gameManager.alloys[1]--;
                break;
            case ((int)Ores.Lead):
                if (gameManager.alloys[2] == 0)
                    return;
                gameManager.alloys[2]--;
                break;
            case ((int)Ores.Gold):
                if (gameManager.alloys[3] == 0)
                    return;
                gameManager.alloys[3]--;
                break;
            case ((int)Ores.Silver):
                if (gameManager.alloys[4] == 0)
                    return;
                gameManager.alloys[4]--;
                break;
            case ((int)Ores.Aluminium):
                if (gameManager.alloys[5] == 0)
                    return;
                gameManager.alloys[5]--;
                break;

        }
        gameManager.setOreProduction(oreNumber, gameManager.getOreProduction(oreNumber) + 1.5f);
    }

    public void PlayButton()
    {
        Application.Quit();
    }

    public void AlloysWindowOpen(GameObject window)
    {
        if (currentOpenWindow)
            currentOpenWindow.SetActive(false);

        window.SetActive(true);
        currentOpenWindow = window;
        timer = 1.0f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentOpenWindow)
            {
                currentOpenWindow.SetActive(false);
                currentOpenWindow = null;
            }
            else
            {
                if (canvasWindows[0].name != "ConfirmExitWindow")
                {
                    Debug.LogError("Error, wrong windows setup");
                    return;
                }
                canvasWindows[0].SetActive(true);
                currentOpenWindow = canvasWindows[0];
            }
        }

        if(currentOpenWindow && currentOpenWindow.name == "OresWindow")
        {
            timer += Time.deltaTime;
            if (timer >= 1.0f)
            {
                for (int i = 0; i < (int)Ores.Last; i++)
                {
                    oresValues[i].text = ((int)gameManager.ores[i]).ToString();
                }
                timer = 0;
            }
            
        }
        if (currentOpenWindow && currentOpenWindow.name == "AlloysWindow")
        {
            timer += Time.deltaTime;
            if (timer >= 1.0f)
            {
                for (int i = 0; i < (int)Alloys.Last; i++)
                {
                    alloysValues[i].text = ((int)gameManager.alloys[i]).ToString();
                }
                timer = 0;
            }

        }
    }

    
}
