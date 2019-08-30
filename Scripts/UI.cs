using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
/// <summary>
/// Group All User interface elements together for GameCtr.
/// </summary>
[Serializable]
public class UI {
	[Header("Text")]
	public Text textScore;
	public Text textTimer;
	public Text finalTextScore;
	public Text finalTextTimer;
	public Text correctText;
	public Text incorrectText;
	public Text gfinalTextScore;
	public Text gfinalTextTimer;
	public Text gcorrectText;
	public Text gincorrectText;

	public Image cap;
	public Sprite gold;
	public Sprite silver;
	public Sprite bronz;

	public GameObject levelCompletePanel;
	public GameObject GameOverPanel;
}
