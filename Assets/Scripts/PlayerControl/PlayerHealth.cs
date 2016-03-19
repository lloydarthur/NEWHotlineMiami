using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	// Use this for initialization
	public int startingHeath;
	public int currentHealth;
	public Slider HealthSlider;
	public Image damageImage;
	public float flashSpeed =5f;
	public Color flashColour = new Color(1f,0f,0f,0.1f);

	bool damaged;

	void Awake()
	{
		currentHealth = startingHeath;

	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
