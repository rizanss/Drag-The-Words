using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class ManagerKata : MonoBehaviour
{
    public static ManagerKata Instance { get; private set; }
    [SerializeField] DragScript hurufPrefab;
    [SerializeField] Transform slotAwal, slotAkhir;
    [SerializeField] string[] listKataKata;

    private int poinKata, poin;

    public GameManagerScript gameManager;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        InitKata(listKataKata[0]);
    }

    void InitKata(string kata)
    {
        char[] hurufKata = kata.ToCharArray();
        char[] hurufAcak = new char[hurufKata.Length];

        List<char> hurufKataCopy = new List<char>();
        hurufKataCopy = hurufKata.ToList();

        for (int i = 0; i < hurufAcak.Length; i++)
        {
            int randomIndex = Random.Range(0, hurufKataCopy.Count);
            hurufAcak[i] = hurufKataCopy[randomIndex];
            hurufKataCopy.RemoveAt(randomIndex);

            DragScript temp = Instantiate(hurufPrefab, slotAwal);

            temp.Inisialiasi(slotAwal, hurufAcak[i].ToString(), false);
        }

        for (int i = 0; i < hurufKata.Length; i++)
        {
            DragScript temp = Instantiate(hurufPrefab, slotAkhir);

            temp.Inisialiasi(slotAkhir, hurufKata[i].ToString(), true);
        }

        poinKata = hurufKata.Length;
    }

    public void TambahPoin()
    {
        poin++;

        if (poin == poinKata)
        {
            SceneManager.LoadSceneAsync(4);
        }
    }
}
