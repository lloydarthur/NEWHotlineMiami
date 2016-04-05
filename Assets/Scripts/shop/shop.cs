using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class shop : MonoBehaviour {
	public GameObject Gamemgn=null;
	// enter the shop
	public Image EnterShop = null;
	public Button YesButton = null;
	public Button NoButton = null;
	public Text EnterShop_text = null;
	// shop
	public Image Shop = null;
	public ScrollRect ScrollView= null;
	public Button BuyButton = null;
	public Button ExistButton = null;
	public Image Description = null;
	///public Text  Description_test = null;
	public Image Descriptionborder = null;
	public Image ScrollbarA = null;
	public Image handle= null;
	public Button[] item = null;
	public Text[] price = null;
	public Image[] priceicon = null;
	public int SGAPrice  ;
	public int RAPrice;
	public int HGAPrice;
	public int HPPrice ;
	bool SGABUY = false;
	bool HGABUY = false;
	bool RABUY = false;
	bool HPBUY = false;
	void intializeShopComponents() 
	{
		if (EnterShop == null) {
			EnterShop = GameObject.FindGameObjectWithTag ("EnterShop").GetComponent<Image>();
		} else {

		}
		if (YesButton == null) {
			YesButton = GameObject.FindGameObjectWithTag ("YesButton").GetComponent<Button>();
		} else {

		}
		if (NoButton == null) {
			NoButton = GameObject.FindGameObjectWithTag ("NoButton").GetComponent<Button>();
		} else {

		}
		if (EnterShop_text== null) {
			EnterShop_text= GameObject.FindGameObjectWithTag ("EnterShopText").GetComponent<Text>();
		} else {

		}
			
	}
	void intializeShop()
	{
		price [0].text = SGAPrice.ToString();// SGAPrice
		price [1].text = HGAPrice.ToString(); // HGAPrice
		price [2].text = RAPrice.ToString(); // RAPrice
		price [3].text = HPPrice.ToString(); // HPPrice

		Description.GetComponentInChildren<Text>().text = "info:";

	}
	// Use this for initialization
	void Start () 
	{
		//ExistTheShop ();
		closeShop ();
	}



		void EnterTheShop()
	{
		EnterShop.enabled = true;
		EnterShop_text.enabled = true;
		YesButton.GetComponent<Button>().enabled = true;
		YesButton.GetComponent<Image>().enabled = true;
		YesButton.GetComponentInChildren<Text>().enabled = true;
		NoButton.GetComponent<Button>().enabled = true;
		NoButton.GetComponent<Image>().enabled = true;
		NoButton.GetComponentInChildren<Text>().enabled = true;


	}

	public void ExistTheShop()
	{
		EnterShop.enabled = false;
		EnterShop_text.enabled = false;
		YesButton.GetComponent<Button>().enabled = false;
		YesButton.GetComponent<Image>().enabled = false;
		YesButton.GetComponentInChildren<Text>().enabled = false;
		NoButton.GetComponent<Button>().enabled = false;
		NoButton.GetComponent<Image>().enabled = false;
		NoButton.GetComponentInChildren<Text>().enabled = false;

	}

	public void OnSell()
	{
		intializeShop ();
		Shop.enabled = true;
		BuyButton.GetComponent<Button>().enabled = true;
		BuyButton.GetComponent<Image>().enabled = true;
		BuyButton.GetComponentInChildren<Text>().enabled = true;
		ExistButton.GetComponent<Button>().enabled = true;
		ExistButton.GetComponent<Image>().enabled = true;
		ExistButton.GetComponentInChildren<Text>().enabled = true;
		Description.GetComponent<Image> ().enabled = true;
		Descriptionborder.GetComponent<Image>().enabled = true;
		Description.GetComponentInChildren<Text> ().enabled = true;
		ScrollView.GetComponent<ScrollRect> ().enabled = true;
		ScrollView.GetComponentInChildren<Image> ().enabled = true;
		ScrollbarA.GetComponent<Image> ().enabled = true;
		handle.GetComponent<Image> ().enabled = true;
		for (int j = 0; j < item.Length; ++j) 
		{
			
			item [j].GetComponent<Image> ().enabled = true;
			item [j].GetComponentInChildren<Text> ().enabled = true;
			price [j].GetComponentInChildren<Text> ().enabled = true;
			priceicon [j].GetComponentInChildren<Image> ().enabled = true;
		}
		ExistTheShop ();

	}

	public void closeShop()
	{
		Shop.enabled = false;
		BuyButton.GetComponent<Button>().enabled = false;
		BuyButton.GetComponent<Image>().enabled = false;
		BuyButton.GetComponentInChildren<Text>().enabled = false;
		ExistButton.GetComponent<Button>().enabled = false;
		ExistButton.GetComponent<Image>().enabled = false;
		ExistButton.GetComponentInChildren<Text>().enabled = false;
		Description.GetComponent<Image> ().enabled = false;
		Descriptionborder.GetComponent<Image>().enabled = false;
		Description.GetComponentInChildren<Text> ().enabled = false;
		ScrollView.GetComponent<ScrollRect> ().enabled = false;
		ScrollView.GetComponentInChildren<Image> ().enabled = false;
		ScrollView.GetComponentInChildren<ScrollRect> ().enabled = false;
		ScrollbarA.GetComponent<Image> ().enabled = false;
		handle.GetComponent<Image> ().enabled = false;
		for (int i = 0; i < item.Length; ++i) 
		{ 
			
			item [i].GetComponent<Image> ().enabled = false;
			item [i].GetComponentInChildren<Text> ().enabled = false;
			price [i].GetComponentInChildren<Text> ().enabled = false;
			priceicon [i].GetComponentInChildren<Image> ().enabled = false;
		}

	}




	public  void healthpack()
	{
		Description.GetComponentInChildren<Text> ().text = "info: Heath packs give you health";
		HPBUY = true;
		HGABUY = false;
		SGABUY = false;
		RABUY = false;
	}

	public  void HGD()
	{
		Description.GetComponentInChildren<Text> ().text = "info: you will get HandGun Ammo";
		HGABUY = true;
		SGABUY = false;
		RABUY = false;
		HPBUY = false;
	}
	public  void SGD()
	{
		Description.GetComponentInChildren<Text> ().text = "info: you will get ShotGun Ammo";
		SGABUY = true;
		RABUY = false;
		HPBUY = false;
		HGABUY = false;
	}
	public  void RD()
	{
		Description.GetComponentInChildren<Text> ().text = "info: you will get Rife Ammo";
		RABUY = true;
		HPBUY = false;
		HGABUY = false;
		SGABUY = false;
	}
	public  void Buy()
	{
		if (SGABUY == true&& Gamemgn.GetComponent<GameManager> ().PlayerScore > SGAPrice ) 
		{
			Gamemgn.GetComponent<GameManager> ().PlayerScore -= SGAPrice;
			Gamemgn.GetComponent<GameManager> ().ShotGunAmmon += 14;

		}
		else if (HGABUY == true && Gamemgn.GetComponent<GameManager> ().PlayerScore > HGAPrice) 
		{
			Gamemgn.GetComponent<GameManager> ().PlayerScore -= HGAPrice;
			Gamemgn.GetComponent<GameManager> ().HandGunAmmon += 7;

		}
		else if (RABUY == true&& Gamemgn.GetComponent<GameManager> ().PlayerScore > RAPrice) 
		{
			Gamemgn.GetComponent<GameManager> ().PlayerScore -= RAPrice;
			Gamemgn.GetComponent<GameManager> ().RifeAmmon +=24;

		}
		else if (HPBUY == true&& Gamemgn.GetComponent<GameManager> ().PlayerScore > HPPrice) 
		{
			Gamemgn.GetComponent<GameManager> ().PlayerScore -= HPPrice;
			Gamemgn.GetComponent<GameManager> ().PlayerHealth += 25;

		}
	}

	// Update is called once per frame
	void Update () {

	}
}
