using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float[] ores = new float[(int)Ores.Last];
    public int[] alloys = new int[(int)Alloys.Last];
    public float[] oresProduction = new float[(int)Ores.Last];

    [SerializeField]
    UIManager uiManager;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        for (int i = 0; i < (int)Ores.Last; i++)
        {
            oresProduction[i] = 0.5f;
        }
        oresProduction[(int)Ores.Copper] = 2.0f;

    }

    public float getOreProduction(int oreNumber)
    {
        return oresProduction[oreNumber];
    }

    public void setOreProduction(int oreNumber, float production)
    {
        oresProduction[oreNumber] = production;
    }

    public void createAlloy(int oreNumber)
    {
        int oresRemove = 20;
        if (ores[oreNumber] <= oresRemove)
            return;
        switch (oreNumber)
        {
            case ((int)Ores.Copper):
                Debug.Log("Start: " + oreNumber);
                ores[oreNumber] -= oresRemove;
                StartCoroutine(smeltAlloy(4, (int)Alloys.CopperBar));
                break;
            case ((int)Ores.Iron):
                ores[oreNumber] -= oresRemove;
                StartCoroutine(smeltAlloy(4, (int)Alloys.IronBar));
                break;
            case ((int)Ores.Lead):
                ores[oreNumber] -= oresRemove;
                StartCoroutine(smeltAlloy(4, (int)Alloys.LeadBar));
                break;
            case ((int)Ores.Gold):
                ores[oreNumber] -= oresRemove;
                StartCoroutine(smeltAlloy(4, (int)Alloys.GoldBar));
                break;
            case ((int)Ores.Silver):
                ores[oreNumber] -= oresRemove;
                StartCoroutine(smeltAlloy(4, (int)Alloys.SilverBar));
                break;
            case ((int)Ores.Aluminium):
                ores[oreNumber] -= oresRemove;
                StartCoroutine(smeltAlloy(4, (int)Alloys.AluminiumBar));
                break;

        }
            

    }

    IEnumerator smeltAlloy(float time, int alloyNumber)
    {
        float timer = 0;
        while(timer <= time)
        {
            yield return null;
            timer += Time.deltaTime;
        }
        alloys[alloyNumber] += 1;
    }
    
    void Update()
    {
        for (int i = 0; i < (int)Ores.Last; i++)
        {
            ores[i] += oresProduction[i] * Time.deltaTime;
        }
    }
}
