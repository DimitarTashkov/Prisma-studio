using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisma_studio.Models.DbConfiguration
{
    public static class SeedAdmin
    {
        public static async Task SeedAdminUserAsync()
        {
            using (var context = new HotelContext())
            {
                var adminRole = await context.Roles.FirstOrDefaultAsync(r => r.Name == "Admin");

                if (adminRole == null)
                {
                    adminRole = new Role { Id = Guid.NewGuid(), Name = "Admin" };
                    context.Roles.Add(adminRole);
                    await context.SaveChangesAsync();
                }

                    var existingAdmin = await context.Users.FirstOrDefaultAsync(u => u.Username == "\"foulcoast\"");

                if (existingAdmin == null)
                {

                        var adminUser = new User
                        {
                            Username = "\"foulcoast\"",
                            Password = "\"mitko123\"",
                            Email = "admin@example.com",
                            AvatarUrl = Path.Combine(Application.StartupPath, "Resources", "admin_avatar")
                        };

                        context.Users.Add(adminUser);
                        await context.SaveChangesAsync();

                        var adminUserRole = new UserRole
                        {
                            UserId = adminUser.Id,
                            RoleId = adminRole.Id
                        };

                        context.UsersRoles.Add(adminUserRole);
                        await context.SaveChangesAsync();
                    
                }

                }
            }
        }
    }
