using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chirper.API.Models
{
    public class Comment
    {
        //primary key
        public int CommentId { get; set; }

        //foreigh key 
        public string UserId { get; set; }

        //comment fields
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LinkedCount { get; set; }

        //entity relationships
        public int ChirpId { get; set; }
        public virtual Chirp Chirp { get; set; }
        public virtual ChirperUser User { get; set; }
    }
}