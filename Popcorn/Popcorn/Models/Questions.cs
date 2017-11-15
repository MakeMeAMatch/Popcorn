using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Popcorn.Models
{
    public class Questions
    {
        public int Id
        {
            get; set;
        }
        public List<string> Answers
        {
            get; set;
        }
        public string QuestionText
        {
            get; set;
        }
        Dictionary<int, string> MyDictionary;
    }
}
