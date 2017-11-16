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
        //created a list of personality(s) in order to add a list of objects to my database
        public List<Personality> Answers
        {
            get; set;
        }
        public string QuestionText
        {
            get; set;
        }
    }
}
