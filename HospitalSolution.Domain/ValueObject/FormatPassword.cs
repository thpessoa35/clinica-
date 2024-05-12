
using System.Text.RegularExpressions;

namespace formatPassword;

public static class FormatPassword
{
    public static void IsValidPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("A senha não pode ser vazia.", nameof(password));
        }

        if (password.Length < 8)
        {
            throw new ArgumentException("A senha deve ter pelo menos 8 caracteres.", nameof(password));
        }

        if (!ContainsUpperCase(password))
        {
            throw new ArgumentException("A senha deve conter pelo menos uma letra maiúscula.", nameof(password));
        }

        if (!ContainsLowerCase(password))
        {
            throw new ArgumentException("A senha deve conter pelo menos uma letra minúscula.", nameof(password));
        }

        if (!ContainsDigit(password))
        {
            throw new ArgumentException("A senha deve conter pelo menos um dígito.", nameof(password));
        }

        if (!ContainsSpecialCharacter(password))
        {
            throw new ArgumentException("A senha deve conter pelo menos um caractere especial.", nameof(password));
        }
    }

    private static bool ContainsUpperCase(string password)
    {
        return Regex.IsMatch(password, "[A-Z]");
       
    }

    private static bool ContainsLowerCase(string password)
    {
        return Regex.IsMatch(password, "[a-z]");
    }

    private static bool ContainsDigit(string password)
    {
        return Regex.IsMatch(password, "[0-9]");
    }

    private static bool ContainsSpecialCharacter(string password)
    {
        return Regex.IsMatch(password, "[^a-zA-Z0-9]");
    }
}

