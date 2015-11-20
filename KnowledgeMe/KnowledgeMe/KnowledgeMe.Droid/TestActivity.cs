
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace KnowledgeMe.Droid
{
    [Activity(Label = "TestActivity")]
    public class TestActivity : Activity
    {
        private UserTestPreferences user;
        private Button nextTestBtn;
        private TextView questionText;
        private TextView questionTitle;
        private TextView correctQuestionText;
        private int questionNumber = 1;
        private RadioGroup radioGroup;
        private RadioButton radioBtn1;
        private RadioButton radioBtn2;
        private RadioButton radioBtn3;
        List<RadioButton> radioButtons;
        private string content;
        private TestFormulator test;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.TestStartPage);


            user = new UserTestPreferences();
            if (Intent.GetStringExtra("Language") != null)
                user.Language = Intent.GetStringExtra("Language");

            if (Intent.GetStringExtra("Difficulty") != null)
                user.Difficulty = Intent.GetStringExtra("Difficulty");

            string openXml = "";
            if (user.Language.ToLower() == "c#")
            {
                openXml = "csharp.xml";
            }else if(user.Language.ToLower() == "javascript")
            {
                openXml = user.Language.ToLower() + ".xml";
            }else if (user.Language.ToLower() == "java")
            {
                openXml = user.Language.ToLower() + ".xml";

            }
            using (StreamReader sr = new StreamReader(Assets.Open(openXml) ) )
            {
                content = sr.ReadToEnd();
            }
            
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(content);
            
            // Create your application here
            TextView langText = FindViewById<TextView>(Resource.Id.testLanguage);
            TextView difText = FindViewById<TextView>(Resource.Id.testDifficulty);
            langText.Text = user.Language;
            difText.Text = user.Difficulty;

            questionTitle = FindViewById<TextView>(Resource.Id.textViewQuestionTitle);
            questionTitle.Text = "Question number " + questionNumber.ToString();

            test = new TestFormulator(user.Difficulty, user.Language, xml);
            test.StartTest();
            questionText = FindViewById<TextView>(Resource.Id.textViewQuestion);
            if(test.Question != null)
            {
                questionText.Text = test.Question;
            }

            radioGroup = FindViewById<RadioGroup>(Resource.Id.radioGroup);
            radioBtn1 = FindViewById<RadioButton>(Resource.Id.radioButtonAlternative1);
            radioBtn2 = FindViewById<RadioButton>(Resource.Id.radioButtonAlternative2);
            radioBtn3 = FindViewById<RadioButton>(Resource.Id.radioButtonAlternative3);
            radioButtons = new List<RadioButton>();
            radioButtons.Add(radioBtn1);
            radioButtons.Add(radioBtn2);
            radioButtons.Add(radioBtn3);

            List<string> radioButtonStringAlternatives = new List<string>();
            foreach (var item in test.RadioButtonAlternatives[0])
            {
                radioButtonStringAlternatives.Add(item);
            }
            int i = 0;
            foreach (var radioAlternative in radioButtons)
            {
                radioAlternative.Text = radioButtonStringAlternatives[i++];
                radioAlternative.Click += RadioAlternative_Click;
            }
            nextTestBtn = FindViewById<Button>(Resource.Id.btnNextQuestion);
            nextTestBtn.Click += NextTestBtn_Click;
        }

        private void RadioAlternative_Click(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb == radioButtons[test.CorrectAnswer])
            {
                rb.SetBackgroundColor(Android.Graphics.Color.Green);
            }
            else
            {
                radioButtons[test.CorrectAnswer].SetBackgroundColor(Android.Graphics.Color.Green);
                rb.SetBackgroundColor(Android.Graphics.Color.Red);
            }
        }
        
        private void NextTestBtn_Click(object sender, EventArgs e)
        {
            if (questionNumber < test.NumberOfQuestions)
            {
                questionNumber++;
                correctQuestionText = FindViewById<TextView>(Resource.Id.textViewCorrectAnswer);
                correctQuestionText.Text = test.CorrectAnswer.ToString();
                ResetTest();
                test.CreateQuestion();
                List<string> radioButtonStringAlternatives = new List<string>();
                foreach (var item in test.RadioButtonAlternatives[0])
                {
                    radioButtonStringAlternatives.Add(item);
                }
                int i = 0;
                foreach (var radioAlternative in radioButtons)
                {
                    radioAlternative.Text = radioButtonStringAlternatives[i++];
                    radioAlternative.Click += RadioAlternative_Click;
                }
                if (test.Question != null)
                    questionText.Text = test.Question;

                questionTitle.Text = "Question number " + questionNumber.ToString();
            }
            else
            {
                TextView alertView = FindViewById<TextView>(Resource.Id.textViewAlert);
                alertView.Text = "Slut på frågor tyvärr...";
                alertView.Visibility = Android.Views.ViewStates.Visible;


            }
        }

        private void ResetTest()
        {
            foreach (var rb in radioButtons)
            {
                rb.SetBackgroundColor(Android.Graphics.Color.Transparent);
                rb.Checked = false;
                rb.Text = "";
            }
            correctQuestionText.Text = "";
            questionText.Text = "";
            questionTitle.Text = "";
        }
    }
}