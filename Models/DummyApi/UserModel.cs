using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace helloralph.Models.DummyApi
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }
        public string Picture { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string RegisterDate { get; set; }
        public LocationModel Location { get; set; }
    }
}
