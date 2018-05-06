using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperDirector : MonoBehaviour {

	// HingeJointコンポーネントを入れる
	private HingeJoint leftHingeJoint;
	private HingeJoint rightHingeJoint;

	// 初期の傾き
	private float defaultAngle = 20;

	// 弾いた時の傾き
	private float flickAngle = -20;

	// 画面幅を取得
	private int width = Screen.width;

	// Use this for initialization
	void Start () {
		// HingeJointコンポーネントの取得
		GameObject leftFripper = GameObject.Find("LeftFripper");
		GameObject rightFripper = GameObject.Find("RightFripper");
		leftHingeJoint = leftFripper.GetComponent<HingeJoint>();
		rightHingeJoint = rightFripper.GetComponent<HingeJoint>();
	}

	// Update is called once per frame
	void Update () {
		foreach(var touch in Input.touches) {
			if(touch.phase == TouchPhase.Began) {
				SetBeganAngle(touch.position);
			} else if(touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended) {
				SeEndedAngle(touch.position);
			}
		}
	}

	public void SetBeganAngle(Vector2 position) {
		if(position.x < this.width / 2) {
			JointSpring leftJointSpr = this.leftHingeJoint.spring;
			leftJointSpr.targetPosition = this.flickAngle;
			this.leftHingeJoint.spring = leftJointSpr;
		} else {
			JointSpring rightJointSpr = this.rightHingeJoint.spring;
			rightJointSpr.targetPosition = this.flickAngle;
			this.rightHingeJoint.spring = rightJointSpr;
		}
	}

	public void SeEndedAngle(Vector2 position) {
		if(position.x < this.width / 2) {
			JointSpring leftJointSpr = this.leftHingeJoint.spring;
			leftJointSpr.targetPosition = this.defaultAngle;
			this.leftHingeJoint.spring = leftJointSpr;
		} else {
			JointSpring rightJointSpr = this.rightHingeJoint.spring;
			rightJointSpr.targetPosition = this.defaultAngle;
			this.rightHingeJoint.spring = rightJointSpr;
		}
	}
}
