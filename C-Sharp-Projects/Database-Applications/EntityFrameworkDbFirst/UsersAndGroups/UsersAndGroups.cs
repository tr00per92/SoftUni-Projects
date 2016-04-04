namespace UsersAndGroups
{
    using System.Linq;

    public static class UsersAndGroups
    {
        public static void Main()
        {
            AddNewAdmin("Peshko", "Pesho Admin4eto");
            AddNewAdmin("Goshko", "Gecata Super Administrator");
        }

        public static void AddNewAdmin(string username, string fullName)
        {
            using (var db = new UsersAndGroupsEntities())
            {
                var adminsGroup = db.Groups.FirstOrDefault(g => g.Name == "Admins");
                if (adminsGroup == null)
                {
                    db.Groups.Add(new Group
                    {
                        Name = "Admins",
                        Users = new[] { new User { Username = username, FullName = fullName }}
                    });
                }
                else
                {
                    adminsGroup.Users.Add(new User { Username = username, FullName = fullName });
                }

                db.SaveChanges();
            }
        }
    }
}
