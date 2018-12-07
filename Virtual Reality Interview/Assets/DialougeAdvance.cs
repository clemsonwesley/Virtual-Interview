﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using TMPro;


public class DialougeAdvance : MonoBehaviour
{

    public Text myText;
	public TextMeshProUGUI time1;
	public TextMeshProUGUI time2;
	public TextMeshProUGUI time3;
	public TextMeshProUGUI time4;
	public TextMeshProUGUI time5;
	public TextMeshProUGUI time6;
	public TextMeshProUGUI time7;
	public TextMeshProUGUI time8;
	public TextMeshProUGUI time9;
	public TextMeshProUGUI time10;

    private int i;
	private HashSet<int> numbers = new HashSet<int>();
	private int [] timeSet = new int[5];
	private int counter = 1;
	float timerr = 0;
	
    private string[] questions = { "Interviewer: Tell me about yourself?",
								   "Interviewer: What would you say is your greatest strength?",
                                   "Interviewer: What do you see as your greatest weakness?",
                                   "Interviewer: What are your long term career goals?",
                                   "Interviewer: Explain a time when you had a conflict within a group and how you solved it?",
								   "Interviewer: Talk about a time you worked with a group of culturally different people and what were the challenges you faced?",
								   "Interviewer: What type of group dynamic do you prefer in a professional setting?",
								   "Interviewer: Why do you want to be in this career field?"};

    private string[] tips = { "Tip: Try not to tell your whole life story, focus on things like education and career history. If possible, focus on things relevant to the position you’re applying to. ",
                                   "Tip: Be honest but try not to come across as arrogant. Try to pull out strengths and traits that you haven’t discussed in other aspects of the interview",
                                   "Tip: They’re testing self-awareness and honesty. Say something you honestly struggle with but follow it up by saying how you work around it or are improving.",
                                   "Tip: There’s no real right answer to this, try to give a realistic career path for you. Make sure that you don’t imply you’ll be leaving the company any time soon.",
                                   "Tip: Focus on what the problem was and how you resolved it peacefully. Don’t talk bad about the individuals within the group.",
								   "Tip: Focus only on the problems that arose because if the cultural differences, don’t bad mouth the other group members. Be sure to be able to talk about how you solved any problems.",
								   "Tip: Be honest, but don’t make it seem as if everything must be exactly how you want it. People will be less likely to offer you a job if they think you’ll fit in the environment.",
								   "Tip: The answer to this question depends greatly on the exact career field you’re entering. Be honest and talk about why you enjoy it, and the future of the field."};

	

    public AudioClip interview1;
    public AudioClip interview2;
    public AudioClip interview3;
    public AudioClip interview4;
    public AudioClip interview5;
	public AudioClip interview6;
	public AudioClip interview7;
	public AudioClip Interview8;

	private float clipTimeAvg = 2.875f;
	//public AudioClip intro;
	public AudioClip outro;

    //public GameObject intro;
    //public GameObject introSquare;

    private AudioSource source;
	public GameObject can;
	public GameObject can2;
    

    // Use this for initialization
    void Start()
    {
        //TipsToggle.tipsOn = 0;
        source = GetComponent<AudioSource>();

        myText.text = "";
        i = 0;
    }

	

    // Update is called once per frame
    void Update()
    {

		timerr += Time.deltaTime;
        if (OVRInput.GetDown(OVRInput.Button.One) && Time.timeScale != 0.0f)
        {
            /*if (i == 0)
            {
                intro.SetActive(false);
                introSquare.SetActive(false);

            }*/

			//Reset timer for first question
			if(counter == 1){
				timerr = 0;
			}

            myText.text = "";

			if(counter >= 2){
			timerr -= clipTimeAvg;
			TimeSpan timespan = TimeSpan.FromSeconds((int)timerr);
			int min = timespan.Minutes;
			int sec = timespan.Seconds;
			
			if(counter == 2){
				time1.text = min.ToString();
				time6.text = sec.ToString();
			}
			if(counter == 3){
				time2.text = min.ToString();
				time7.text = sec.ToString();
			}
			if(counter == 4){
				time3.text = min.ToString();
				time8.text = sec.ToString();
			}
			if(counter == 5){
				time4.text = min.ToString();
				time9.text = sec.ToString();
			}
			if(counter == 6){
				time5.text = min.ToString();
				time10.text = sec.ToString();
			}

			//Debug.Log(min);
			//Debug.Log(sec);
			//timeSet[counter-2] = sec;
			timerr = 0;

		}

			if(counter < 6){
			
            StartCoroutine("Dialouge");
			}

			if(counter == 6){

				myText.text = "";
			//Debug.Log("Made it");
			source.PlayOneShot(outro, 1);
			Thread.Sleep(6);
				can2.SetActive(true);
			}
        }
        if(OVRInput.GetDown(OVRInput.Button.Start))
        {
            if (Time.timeScale == 1.0f){
                Time.timeScale = 0.0f;
				can.SetActive(true);
				source.Pause();
				}

            else{
                Time.timeScale = 1.0f;
				can.SetActive(false);
				source.Play();
				}
        }

		
    }

	

    IEnumerator Dialouge()
    {

		//Debug.Log(TipsToggle.tipsOn);
		//Interview stopper statement -- end

		
			
		if (counter == 6)
        {
            
			yield return new WaitForSeconds(1);
        }
        

		i = UnityEngine.Random.Range(0,7);
		while(numbers.Contains(i)){
			i = UnityEngine.Random.Range(0,7);
			//Debug.Log(i);
		}
		numbers.Add(i);

		if(interviewerMute.textOn == 1){
		
			myText.text = "";

		}
		else{
        if (i < 8)
        {
            myText.text = questions[i];
        }
		}
		if(interviewerMute.voiceOn == 1){
			yield return new WaitForSeconds(5);
		}
		else{
        if (i == 0) { 
			//myText.text = "";
			//source.PlayOneShot(intro, 1);
			//Thread.Sleep(5);
			//myText.text = questions[i];
			source.PlayOneShot(interview1, 1);
            yield return new WaitForSeconds(interview1.length);
        }
        if (i == 1) { source.PlayOneShot(interview2, 1);
            yield return new WaitForSeconds(interview2.length);
        }
        if (i == 2) { source.PlayOneShot(interview3, 1);
            yield return new WaitForSeconds(interview3.length);
        }
        if (i == 3) { source.PlayOneShot(interview4, 1);
            yield return new WaitForSeconds(interview4.length);
        }
        if (i == 4) { source.PlayOneShot(interview5, 1);
            yield return new WaitForSeconds(interview5.length);
        }
		if (i == 5) { source.PlayOneShot(interview6, 1);
            yield return new WaitForSeconds(interview5.length);
        }
		if (i == 6) { source.PlayOneShot(interview7, 1);
            yield return new WaitForSeconds(interview5.length);
        }
		if (i == 7) { source.PlayOneShot(Interview8, 1);
            yield return new WaitForSeconds(interview5.length);
        }
		}
		
		if(interviewerMute.textOn == 1){
			myText.text = "";
		}
		else{
		if (i < 8 && TipsToggle.tipsOn == 1)
        {
            myText.text = tips[i];
        }
		}

		counter++;
        //yield return new WaitForSeconds(5f);
        
        

    }
}
