using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header("Money")]
    public int money;
    [SerializeField] private TextMeshProUGUI moneyUI;
    [SerializeField] private TextMeshPro shopMoneyUI;

    [Header("Spawning Items")]
    [SerializeField] private GameObject emptyItemCard;
    [SerializeField] private List<SmithingScriptableObj> ItemsToSpawn;
    [SerializeField] private Transform itemSpawnPos;
    [SerializeField] private GameObject shopDoorOpen, shopDoorClosed;
    [SerializeField] private float timeOnShowFor = 40f;
    [SerializeField] private GameObject progressBar;
    private float timer;
    private GameObject itemOnShow;
    [Header("Juice")]
    [SerializeField] private GameObject[] teeth;
    private int teethActive =0;
    public static ShopManager Instance {get; private set;}
    private AudioSource _audio;
    
    private void Start() {
        Instance = this;
        moneyUI.text = money.ToString();
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        progressBar.transform.localScale = new Vector3(timer/timeOnShowFor,progressBar.transform.localScale.y,progressBar.transform.localScale.z);
        if(timer>= timeOnShowFor){
            timer=0;
            shopDoorOpen.SetActive(true); 
            shopDoorClosed.SetActive(false);
            if(itemOnShow!=null){
                Destroy(itemOnShow);
            }
            SpawnItem();
        }
    }
    private void SpawnItem(){
        SmithingScriptableObj smithObj = ItemsToSpawn[Random.Range(0,ItemsToSpawn.Count)];
        GameObject newItem = Instantiate(emptyItemCard, itemSpawnPos.position, Quaternion.identity);
        newItem.GetComponent<CardDisplay>().smithingObjInfo = smithObj;
        newItem.GetComponent<MoveItem>().isShopItem = true;
        itemOnShow = newItem;
        shopMoneyUI.text = smithObj.cost.ToString();
    }
    public void BuyItem(){
        shopDoorOpen.SetActive(false); 
        shopDoorClosed.SetActive(true);
        money -= itemOnShow.GetComponent<CardDisplay>().smithingObjInfo.cost;
        moneyUI.text = money.ToString();
        itemOnShow = null;
        if(teethActive < teeth.Length){
            teeth[teethActive].SetActive(true);
            teethActive ++;
        }
        shopMoneyUI.text = "";
        _audio.Play();
    }

    public void SellItem(int price){
        money += price;
        moneyUI.text = money.ToString();
    }
}
