using KnowledgeMe.Models;
using System;
using System.Collections.Generic;

namespace KnowledgeMe
{
	public class MyClass
	{
		public MyClass ()
		{

		}
        public int Count { get; set; }
        public string IncreaseCount()
        {
                Count++;
                return "you clicked: " + Count.ToString();
        }
        public List<string> MenuItems()
        {
            List<string> menuArray = new List<string>();
            menuArray.Add("C#");
            menuArray.Add("Java");
            menuArray.Add("Javascript");
            return menuArray;
        }

	}
}

