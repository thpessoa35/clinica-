
using System.Text.RegularExpressions;

namespace emailValidator;

public static class EmailValidator
{
    public static bool IsValid(string email)
    {

        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentException("Email Não pode ser vazio", nameof(email));
        }
        string emailPattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";

        Regex regex = new Regex(emailPattern);

        if (!regex.IsMatch(email))
        {
            throw new ArgumentException("O email fornecido não está em um formato válido.", nameof(email));
        }
        return true;
    }
}
