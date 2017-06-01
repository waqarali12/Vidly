using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomersViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; } //IEnumerable becausein View we only need to iterate over items not other functionalities of list like 'add'.
        public Customer customer { get; set; }
    }
}