namespace TreeNodeApp.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TreeNodeApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TreeNodeApp.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            List<TreeNode> childsLevel2 = new List<TreeNode>()
            {
                new TreeNode { node_name_ar = "الاب 1الابن 1 الابن 1" , node_name_en = "parent1 Child1 Child1",node_parent_id = null},
                new TreeNode { node_name_ar = "الابن 1الاب 1الابن 2" , node_name_en = "parent1 Child1 Child2",node_parent_id = null},
                new TreeNode { node_name_ar = "الابن 1الاب1 الابن 3 " , node_name_en = "parent1 Child1 Child3",node_parent_id = null},
            };

            List<TreeNode> childs = new List<TreeNode>()
            {
                new TreeNode { node_name_ar = "الاب 1الابن 1" , node_name_en = "parent1 Child1",node_parent_id = null,TreeNodeChilds = childsLevel2},
                new TreeNode { node_name_ar = "الابن 1الاب 2" , node_name_en = "parent1 Child2",node_parent_id = null},
                new TreeNode { node_name_ar = "3الابن 1الاب " , node_name_en = "parent1 Child3",node_parent_id = null},
            };

            List<TreeNode> parents = new List<TreeNode>()
            {
                new TreeNode { node_name_ar = "الاب 1" , node_name_en = "parent1",node_parent_id = null,TreeNodeChilds = childs},
                new TreeNode { node_name_ar = "الاب 2" , node_name_en = "parent2",node_parent_id = null},
                new TreeNode { node_name_ar = "الاب 3" , node_name_en = "parent3",node_parent_id = null},
            };

            context.TreeNodes.AddOrUpdate(parents.ToArray());


            //Step 1 Create the user.
            //var passwordHasher = new PasswordHasher();
            //var user = new IdentityUser("Administrator");
            //user.PasswordHash = passwordHasher.HashPassword("Admin12345");
            //user.SecurityStamp = Guid.NewGuid().ToString();
            //
            ////Step 2 Create and add the new Role.
            //var roleToChoose = new IdentityRole("Admin");
            //context.Roles.Add(roleToChoose);
            //
            ////Step 3 Create a role for a user
            //var role = new IdentityUserRole();
            //role.RoleId = roleToChoose.Id;
            //role.UserId = user.Id;
            //
            ////Step 4 Add the role row and add the user to DB)
            //user.Roles.Add(role);
            //context.Users.Add(user);
        }
    }
}
