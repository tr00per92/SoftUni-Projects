//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UsersAndGroups
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public Nullable<int> GroupId { get; set; }
    
        public virtual Group Group { get; set; }
    }
}
