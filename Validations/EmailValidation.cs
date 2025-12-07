using AppCompletoApi.Context;
using AppCompletoApi.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace AppCompletoApi.Validations
{
    public class EmailValidation:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            try
            {
                AppDbContext? context = (AppDbContext)validationContext.GetService(typeof(AppDbContext));
                var usuarioEncontrado = context.Usuario.AsNoTracking().FirstOrDefault(u => u.Email==value);
                return usuarioEncontrado!=null ? new ValidationResult("E-mail já cadastrado") : ValidationResult.Success;
            }
            catch (Exception)
            {
                return new ValidationResult("Erro desconhecido ao validar e-mail");
            }
        }
    }
}
