using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chirper.API.Models
{
    public class Chirp
    {
        //primary key
        public int ChirpId { get; set; }

        //foreighn key
        public string UserId { get; set; }

        //chirp fields
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LinkedCount { get; set; }

        //entity relationships
        public virtual ICollection<Comment> Comments { get; set; }
        
        public virtual ChirperUser User { get; set; }

    }
}