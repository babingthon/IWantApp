﻿using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Authorization;

namespace IWantApp.Endpoints.Employees;

public class EmployeeGetAll
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [Authorize]
    public static IResult Action(int? page, int? rows, QueryAllUsersWithClaimNames query)
    {
        
        
        return Results.Ok(query.Execute(page.Value, rows.Value));
    }

    /*public static IResult Action(int page, int rows, UserManager<IdentityUser> userManager)
    {
        var users = userManager.Users.Skip((page - 1) * rows).Take(rows).ToList();
        var employees = new List<EmployeeResponse>();  
       foreach (var item in users)
        {
            var claims = userManager.GetClaimsAsync(item).Result;
            var claimName = claims.FirstOrDefault(c => c.Type == "Name");
            var userName = claimName != null ? claimName.Value : string.Empty;    
            employees.Add(new EmployeeResponse(item.Email, userName));
        }

        return Results.Ok(new { message = "success", employees });
    }*/

}
