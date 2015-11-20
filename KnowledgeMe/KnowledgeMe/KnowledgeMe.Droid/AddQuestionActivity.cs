using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System.Xml;
using KnowledgeMe.Models;
using System;
using System.IO;

namespace KnowledgeMe.Droid
{
    [Activity(Label = "AddQuestionActivity")]
    public class AddQuestionActivity : Activity
    {
        private string openXml="";
        private XmlDocument xml;
        private Button addQuestionToXmlBtn;
        private TextView questionText;
        private TextView questionAlternative1;
        private TextView questionAlternative2;
        private TextView questionAlternative3;
        private CheckBox checkBoxAlt1;
        private CheckBox checkBoxAlt2;
        private CheckBox checkBoxAlt3;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.AddQuestionPage);
            // Create your application here

            //xml = new XmlDocument();
            addQuestionToXmlBtn = FindViewById<Button>(Resource.Id.AddQuestionToXmlBtn);
            
            string content;
            if (Intent.GetStringExtra("Language") != null)
            {
                if (Intent.GetStringExtra("Language") == "C#")
                    openXml = "csharp.xml";
                else
                    openXml = Intent.GetStringExtra("Language").ToLower()+".xml";
            }

            addQuestionToXmlBtn.Click += AddQuestionToXmlBtn_Click;
        }

        private void AddQuestionToXmlBtn_Click(object sender, EventArgs e)
        {
            questionText = FindViewById<TextView>(Resource.Id.textViewQuestion);
            questionAlternative1 = FindViewById<TextView>(Resource.Id.textViewAlternative1);
            questionAlternative2 = FindViewById<TextView>(Resource.Id.textViewAlternative2);
            questionAlternative3 = FindViewById<TextView>(Resource.Id.textViewAlternative3);
            checkBoxAlt1 = FindViewById<CheckBox>(Resource.Id.checkBox1);
            checkBoxAlt2 = FindViewById<CheckBox>(Resource.Id.checkBox2);
            checkBoxAlt3 = FindViewById<CheckBox>(Resource.Id.checkBox3);

            Question newQuestion = new Question();
            newQuestion.QuestionText = questionText.Text;
            newQuestion.QuestionAlternative1Text = questionAlternative1.Text;
            newQuestion.QuestionAlternative2Text = questionAlternative2.Text;
            newQuestion.QuestionAlternative3Text = questionAlternative3.Text;
            newQuestion.Alt1Correct = checkBoxAlt1.Activated;
            newQuestion.Alt2Correct = checkBoxAlt2.Activated;
            newQuestion.Alt3Correct = checkBoxAlt3.Activated;

            WriteToXml(newQuestion);
            
        }
        public void WriteToXml(Question obj)
        {
            string dif = "";
            if (Intent.GetStringExtra("Difficulty") != null)
                dif = Intent.GetStringExtra("Difficulty").ToString();

            // saveXmlPath makes sure that the xml goes currectly in everycomputer, instead of just wrighting @"C:\MyProject\Blablabla
            //XmlElement xelRoot = xml.DocumentElement;
            //XPathNavigator navigator = xml.CreateNavigator();
            xml = new XmlDocument();
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string filename = System.IO.Path.Combine(path, openXml);
            //xml.CreateComment(openXml);
            xml.Load(Assets.Open(openXml));

            XmlElement question = xml.CreateElement("Question");
            XmlAttribute difficultyAttr = xml.CreateAttribute("value");
            difficultyAttr.InnerText = dif;
            question.Attributes.Append(difficultyAttr);
            XmlNode text = xml.CreateElement("Text");
            text.InnerText = obj.QuestionText;
            question.AppendChild(text);
           /* XmlNode alternatives = xml.CreateElement("Alternatives");
            XmlNode alternative1 = xml.CreateElement("Alternative");
            XmlAttribute correctAttr1 = xml.CreateAttribute("bool");
            correctAttr1.InnerText = obj.Alt1Correct.ToString();
            alternative1.Attributes.Append(correctAttr1);
            alternative1.InnerText = questionAlternative1.Text;
            alternatives.AppendChild(alternative1);

            XmlNode alternative2 = xml.CreateElement("Alternative");
            XmlAttribute correctAttr2 = xml.CreateAttribute("bool");
            correctAttr2.InnerText = obj.Alt2Correct.ToString();
            alternative2.Attributes.Append(correctAttr2);
            alternative2.InnerText = questionAlternative2.Text;
            alternatives.AppendChild(alternative2);

            XmlNode alternative3 = xml.CreateElement("Alternative");
            XmlAttribute correctAttr3 = xml.CreateAttribute("bool");
            correctAttr3.InnerText = obj.Alt3Correct.ToString();
            alternative3.Attributes.Append(correctAttr3);
            alternative3.InnerText = questionAlternative3.Text;
            alternatives.AppendChild(alternative3);

            question.AppendChild(alternatives);*/
            xml.DocumentElement.AppendChild(question);
            //xml.Save(Assets.Open(openXml));
            try
            {
                //xml.Save(filename);
                using (StreamWriter sr = new StreamWriter(filename, true))
                {
                    sr.WriteLine(question);
                    xml.Save(sr);
                }
               Stream myNewXml = new FileStream(filename, FileMode.OpenOrCreate);
            }
            catch (Exception e)
            {
                Console.WriteLine("EXCEPTION "+e);
            }
          
        }
    }
}