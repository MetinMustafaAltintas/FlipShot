using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Top : MonoBehaviour
{
	public Rigidbody2D rbtop;
	public float tophizi = 7;
	public float hizlanmaOrani = 1.1f;
	int skor_oyuncu1;
	int skor_oyuncu2;
	public TextMeshProUGUI Oyuncu1_skor;
	public TextMeshProUGUI Oyuncu2_skor;
	public TextMeshProUGUI Oyuncu1;
	public TextMeshProUGUI Oyuncu2;
	public TextMeshProUGUI Basla;
	public TextMeshProUGUI Oyuncu1Kazandi;
	public TextMeshProUGUI Oyuncu2Kazandi;
	public Vector2 baslangicPozisyon;
	public float yenidenBaslamaSuresi = 0f;
	private bool oyunBasladi = false;

	void Start()
	{
		baslangicPozisyon = transform.position;
		skor_oyuncu1 = 0;
		skor_oyuncu2 = 0;
		Oyuncu1_skor.text = "0";  
		Oyuncu2_skor.text = "0";
		Oyuncu1Kazandi.gameObject.SetActive(false);
		Oyuncu2Kazandi.gameObject.SetActive(false);
	}
	void Update()
	{
		if(!oyunBasladi && Input.GetKeyDown(KeyCode.Space))
		{
			Time.timeScale = 1;
			skor_oyuncu1 = 0;
			skor_oyuncu2 = 0;
			Oyuncu1_skor.text = "0";
			Oyuncu2_skor.text = "0";
			Oyuncu1Kazandi.gameObject.SetActive(false);
			Oyuncu2Kazandi.gameObject.SetActive(false);
			Basla.gameObject.SetActive(false);
			Oyuncu1.gameObject.SetActive(false);
			Oyuncu2.gameObject.SetActive(false);
			oyunBasladi = true;  
			TopuYenidenBaslat();
		}
	}

	void TopuYenidenBaslat()
	{
		transform.position = baslangicPozisyon;
		float x = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
		float y = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
		//rbtop.velocity = new Vector2(x * tophizi, y * tophizi);
		rbtop.velocity = new Vector2(x, y).normalized * tophizi;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			rbtop.velocity = rbtop.velocity.normalized * tophizi * hizlanmaOrani;
			tophizi *= hizlanmaOrani;
		}
		if (collision.gameObject.CompareTag("SolDuvar"))
		{
			skor_oyuncu2++;
			Oyuncu2_skor.text = skor_oyuncu2.ToString();
			TopuGizleVeYenidenBaslat();
			KontrolSkor();
			tophizi = 7;
		}
		else if (collision.gameObject.CompareTag("SagDuvar"))
		{
			skor_oyuncu1++;
			Oyuncu1_skor.text = skor_oyuncu1.ToString();
			TopuGizleVeYenidenBaslat();
			KontrolSkor();
			tophizi = 7;
		}
	}

	void TopuGizleVeYenidenBaslat()
	{
		gameObject.SetActive(false);
		Invoke("TopuGosterVeBaslat", yenidenBaslamaSuresi);
	}

	void TopuGosterVeBaslat()
	{
		gameObject.SetActive(true);
		TopuYenidenBaslat();
	}
	void KontrolSkor()
	{
		if (skor_oyuncu1 >= 5)
		{
			Oyuncu1Kazandi.gameObject.SetActive(true);
			rbtop.gameObject.SetActive(false);
			oyunBasladi = false;
			Basla.gameObject.SetActive(true);
			Oyuncu1.gameObject.SetActive(true);
			Oyuncu2.gameObject.SetActive(true);
			tophizi = 7;
			OyunSonu();
		}
		else if (skor_oyuncu2 >= 5)
		{
			Oyuncu2Kazandi.gameObject.SetActive(true);
			rbtop.gameObject.SetActive(false);
			oyunBasladi = false;
			Basla.gameObject.SetActive(true);
			Oyuncu1.gameObject.SetActive(true);
			Oyuncu2.gameObject.SetActive(true);
			tophizi = 7;
			OyunSonu();
		}
	}

	void OyunSonu()
	{
		Time.timeScale = 0;		 
	}
}
