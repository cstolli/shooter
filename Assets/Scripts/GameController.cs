/**
* @Author: Chris Stoll <chrisstoll>
* @Date:   2017-03-27T18:30:54-07:00
* @Email:  chrispstoll@gmail.com
* @Last modified by:   chrisstoll
* @Last modified time: 2017-03-27T21:08:24-07:00
* @License: MIT
*/



﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public int startWait;
	public int waveWait;

	public Text scoreText;
	public Text restartText;
	public Text gameOverText;

	private int score;
	private bool gameOver;
	private bool restart;

	// Use this for initialization
	void Start () {
		UpdateScore (0);
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		scoreText.text = "";
		StartCoroutine(SpawnWaves ());
	}

	// Update is called once per frame
	void Update () {
		if (restart) {
			if (Input.GetKey (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves() {
		yield return new WaitForSeconds (startWait);
		while (gameOver != true) {
			for (int i = 0; i < hazardCount; i++) {
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			if (gameOver) {
				restartText.text = "Press 'R' to restart";
				restart = true;
				break;
			}
		}
	}

	public void AddScore (int newScoreValue) {
		UpdateScore (score + newScoreValue);
	}

	public void GameOver () {
		gameOverText.text = "You Died";
		gameOver = true;
	}

	void UpdateScore (int newScore) {
		score = newScore;
		scoreText.text = "Score: " + score;
	}
}
