using Java.IO;
using System;
using System.Collections.Generic;
using System.Text;
using Java.Lang;

namespace KnowledgeMe
{

    public class UserTestPreferences : ISerializable
    {
        private string _language;
        private string _difficulty;
        public string Language
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
            }
        }
        public string Difficulty
        {
            get
            {
                return _difficulty;
            }
            set
            {
                _difficulty = value;
            }
        }

        public IntPtr Handle
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public static explicit operator UserTestPreferences(Java.Lang.Object v)
        {
            throw new NotImplementedException();
        }
    }
}
