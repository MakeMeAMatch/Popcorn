﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Popcorn.Models
{
    public class Profiles
    {
        public int Id { get; set; }
        // Each User with their associated set of optional responses
        //changing this ID to a string because the Identity User ID generates a Generic TKey
        public string ApplicationUserId { get; set; }
        public int ResponsesId { get; set; }
        [ForeignKey("AnswersId")]
        public int AnswersId
        {
            get; set;
        }
        [ForeignKey("QuestionsId")]
        public int QuestionsId
        {
            get; set;
        }
    }
}
