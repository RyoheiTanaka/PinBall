using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	// 星小のポイント
	private int smallStar = 5;

	// 星大のポイント
	private int largeStar = 20;

	// 雲小のポイント
	private int smallCloud = 10;

	// 雲大のポイント
	private int largeCloud = 50;

	// スコアの初期値
	private int score = 0;

	// スコアの最大値
	private int maxScore = 999999;

	private GameObject scoreText;

	// Use this for initialization
	void Start() {
		this.scoreText = GameObject.Find("ScoreText");
	}

	// Update is called once per frame
	void Update() {
		// スコアを表示する
		this.scoreText.GetComponent<Text>().text = "SCORE " + this.score;
	}

	void OnCollisionEnter(Collision collision) {
		if(this.score < this.maxScore) {
			// ボールがぶつかったときのタグを判別してスコアに加算
			if(collision.gameObject.tag == "SmallStarTag") {
				if(this.score + this.smallStar >= this.maxScore) {
					this.score = this.maxScore;
				} else {
					this.score += this.smallStar;
				}
			} else if(collision.gameObject.tag == "LargeStarTag") {
				if(this.score + this.largeStar >= this.maxScore) {
					this.score = this.maxScore;
				} else {
					this.score += this.largeStar;
				}
			} else if(collision.gameObject.tag == "SmallCloudTag") {
				if(this.score + this.smallCloud >= this.maxScore) {
					this.score = this.maxScore;
				} else {
					this.score += this.smallCloud;
				}
			} else if(collision.gameObject.tag == "LargeCloudTag") {
				if(this.score + this.largeCloud >= this.maxScore) {
					this.score = this.maxScore;
				} else {
					this.score += this.largeCloud;
				}
			}
		}
	}
}
