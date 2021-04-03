using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.ViewModels
{
    public class ManageOverviewUsersModel
    {
        public string Username { get; set; }
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
    }
}
