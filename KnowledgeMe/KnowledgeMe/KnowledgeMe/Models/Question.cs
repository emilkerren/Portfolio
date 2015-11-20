using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeMe.Models
{
    public class Question
    {
        private string questionText;

        public string QuestionText
        {
            get { return questionText; }
            set { questionText = value; }
        }
        private string questionAlternative1Text;

        public string QuestionAlternative1Text
        {
            get { return questionAlternative1Text; }
            set { questionAlternative1Text = value; }
        }
        private string questionAlternative2Text;

        public string QuestionAlternative2Text
        {
            get { return questionAlternative2Text; }
            set { questionAlternative2Text = value; }
        }
        private bool alt1Correct;
        public bool Alt1Correct
        {
            get { return alt1Correct; }
            set { alt1Correct = value; }
        }
        private bool alt2Correct;
        public bool Alt2Correct
        {
            get { return alt2Correct; }
            set { alt2Correct = value; }
        }
        private bool alt3Correct;
        public bool Alt3Correct
        {
            get { return alt3Correct; }
            set { alt3Correct = value; }
        }
        private string questionAlternative3Text;

        public string QuestionAlternative3Text
        {
            get { return questionAlternative3Text; }
            set { questionAlternative3Text = value; }
        }
    }
}
