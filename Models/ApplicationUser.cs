using System;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreTodo.Models
{
    public class ApplicationUser : IdentityUser
    {
        // //remover os atributos se não precisar caso herde da identityuser
         //public string Id { get; set; }
         //public string Email {get; set; }
    }
}