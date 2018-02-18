using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class UserIndex
    {
        public LoginUser LoginUser {get;set;}
        public RegisterUser RegisterUser {get;set;}
        public List<User> Users {get;set;}
        public UserIndex()
        {
            Users = new List<User>();
        }
    }
    public class WeddingPlannerIndex
    {
        public List<WeddingPlanned> Weddings {get;set;}
        public WeddingPlannerIndex()
        {
            Weddings = new List<WeddingPlanned>();
        }
    }
    public class ShowWedding
    {
        public WeddingPlanned Wedding {get;set;}
    }
}