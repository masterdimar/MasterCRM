using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterCRM.Models
{
    public class ContactsGridModel
    {
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Owner { get; set; }
    }
}