using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roles
{
    /*
     * Imagine we are coding a permissions feature. A list of permissions can be grouped into a Role. Also each Role can include others Roles.
     * 
     * So for example we can have a configuration like this:
     * 
     * Role: "TASK EDITOR"
     * Permissions: "task-read", "task-write"
     * A task editor role can read and update a task.
     * 
     * The goal of this exercise is to create a method that will detect circular references between Roles, for example to prevent a user from doing this.
     * Here is an example of a circular reference:
     * 
     * Role "TASK CREATOR" contains the Role "TASK OWNER" that contains a Role "TASK CREATOR".
     * 
     * Implement "HasCircularReference" method to return TRUE if the Role has a circular reference and FALSE if not.
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // This is just a test example
            var taskReadPermission = new Permission {Id = 1, Name = "task-read"};
            var taskWritePermission = new Permission { Id = 2, Name = "task-write" };
            var taskCreatePermission = new Permission { Id = 3, Name = "task-create" };

            var taskEditorRole = new Role
            {
                Id = 1,
                Name = "TASK EDITOR",
                Roles = new List<Role>(),
                Permissions = new List<Permission> { taskReadPermission, taskWritePermission }
            };

            Console.WriteLine("Role '{0}' has circular reference? {1}", taskEditorRole.Name, HasCircularReference(taskEditorRole, new HashSet<int>()) ? "Yes" : "No");

            var taskCreatorRole = new Role
            {
                Id = 2,
                Name = "TASK CREATOR",
                Roles = new List<Role>
                {
                    new Role
                    {
                        Id = 3,
                        Name = "TASK OWNER",
                        Roles = new List<Role>
                        {
                            new Role
                            {
                                Id = 2,
                                Name = "TASK CREATOR",
                                Roles = new List<Role>(),
                                Permissions = new List<Permission> { taskCreatePermission }
                            }
                        },
                        Permissions = new List<Permission> { taskReadPermission, taskWritePermission }
                    }
                },
                Permissions = new List<Permission> { taskCreatePermission }
            };

            Console.WriteLine("Role '{0}' has circular reference? {1}", taskCreatorRole.Name, HasCircularReference(taskCreatorRole, new HashSet<int>()) ? "Yes" : "No");

            Console.ReadKey();
        }

        public static bool HasCircularReference(Role role, HashSet<int> visitedRoles)
        {
            if (visitedRoles.Contains(role.Id))
            {
                return true;
            }

            visitedRoles.Add(role.Id);

            foreach (var subRole in role.Roles)
            {
                if (HasCircularReference(subRole, new HashSet<int>(visitedRoles)))
                {
                    return true;
                }
            }

            return false;            
        }
    }
}
