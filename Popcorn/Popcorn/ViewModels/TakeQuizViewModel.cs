using Popcorn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Popcorn.ViewModels
{
    public class TakeQuizViewModel
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
        Dictionary<int, string> Dictionary
        {
            get; set;
        }
    }
}
