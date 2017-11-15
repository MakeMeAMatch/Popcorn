using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Popcorn.Models
{
    public class Profiles
    {
        public int Id { get; set; }
        // Each User with their associated set of optional responses
        public int ApplicationUserId { get; set; }
        public int ResponsesId { get; set; }
        public int AnswersId
        {
            get; set;
        }
        public int QuestionsId
        {
            get; set;
        }
    }
}
