using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace KnowledgeMe
{
    public class TestFormulator
    {
        private int _numberOfQuestions;
        private int _i;
        private string _question;
        private int _correct;
        private List<string[]> _questionsAlternativesList;
        private XmlDocument _doc;
        private List<int> correctAnswerList;
        private List<string> questionsList;
        private List<string[]> questionsAlternativesList;
        private string _language;
        private string _difficulty;
        public int NumberOfQuestions
        {
            get { return _numberOfQuestions; }
            private set { _numberOfQuestions = value; }
        }
        public int CorrectAnswer
        {
            get { return _correct; }
            private set { _correct = value; }
        }
        public string Question
        {
            get { return _question; }
            private set { _question = value; }
        }
        public List<string[]> RadioButtonAlternatives
        {
            get { return _questionsAlternativesList; }
            private set { _questionsAlternativesList = value; }
        }

        public TestFormulator(string difficulty, string language, XmlDocument xmlContent)
        {
            _i = -1;
            _difficulty = difficulty;
            _language = language;
            _doc = xmlContent;
        }
        public void StartTest()
        {
            try
            {
                
                XmlElement xelRoot = _doc.DocumentElement;
                XmlNodeList xnlNodes = xelRoot.SelectNodes("/Questions/Question");

                questionsList = new List<string>();
                questionsAlternativesList = new List<string[]>();
                correctAnswerList = new List<int>();
                foreach (XmlNode item in xnlNodes)
                {
                    if (item.Attributes["value"].Value.ToUpper() == _difficulty.ToUpper())
                    {
                        List<string> quest = new List<string>();
                        string[] temp;
                        string encString = item["Text"].InnerXml.ToString();
                        questionsList.Add(encString);
                        var i = 0;
                        foreach (XmlNode alt in item["Alternatives"])
                        {
                            if (alt.Attributes["bool"].Value == "true")
                                correctAnswerList.Add(i);
                            quest.Add(alt.InnerXml);

                            i++;
                        }
                        temp = quest.ToArray();
                        questionsAlternativesList.Add(temp);
                    }
                }
                NumberOfQuestions = questionsList.Count;
            }
            catch (Exception e)
            {
                throw e;
            }
            CreateQuestion();
        }
        public void CreateQuestion()
        {
            Question = null;
            RadioButtonAlternatives = new List<string[]>();
            CorrectAnswer = -1 ;
            _i++;
            switch (_language)
            {
                case "C#":
                    GenerateCSharpQuestion(questionsList, questionsAlternativesList, correctAnswerList);
                    break;
                case "JAVA":
                    GenerateJavaQuestion(questionsList, questionsAlternativesList, correctAnswerList);
                    break;
                case "JAVASCRIPT":
                    GenerateJavascriptQuestion(questionsList, questionsAlternativesList, correctAnswerList);
                    break;
                default:
                    break;
            }
        }
        private void GenerateJavascriptQuestion(List<string> questions, List<string[]> alternatives, List<int> correct)
        {
            
            Question = EncodeXml(questions[_i]);
            RadioButtonAlternatives.Add( alternatives[_i]);
            CorrectAnswer = correct[_i];
        }

        private void GenerateJavaQuestion(List<string> questions, List<string[]> alternatives, List<int> correct)
        {
            Question = EncodeXml(questions[_i]);
            RadioButtonAlternatives.Add(alternatives[_i]);
            CorrectAnswer = correct[_i];
        }

        private void GenerateCSharpQuestion(List<string> questions, List<string[]> alternatives, List<int> correct)
        {
            Question = EncodeXml(questions[_i]);
            RadioButtonAlternatives.Add(alternatives[_i]);
            CorrectAnswer = correct[_i];
        }
        private string EncodeXml(string xml)
        {
            string newXML = xml;
            if (xml.Contains("&amp;")){
                newXML= xml.Replace("&amp;", "&");
            }
            if (xml.Contains("&gt;"))
            {
                newXML=xml.Replace("&gt;", ">");
            }
            if (xml.Contains("&lt;"))
            {
                newXML=xml.Replace("&lt;", "<");
            }
            return newXML;
        }
    }
}
