using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Topic
    {
        public int Id {  get; set; }
        public string Theme {  get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public IdentityUser IdentityUser {  get; set;}
        public HashSet<Post> Posts {  get; set; }
    }
}
