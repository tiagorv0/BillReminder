
using System.Text.RegularExpressions;

namespace BillReminder.Domain.Utils;

public static class PasswordChecker
{
    public static bool IsValid(string password)
    {
        var hasNumber = new Regex(@"[0-9]+");
        var hasUpperChar = new Regex(@"[A-Z]+");
        var especialCharacters = new Regex(@"[^a-zA-Z0-9\s]");

        return hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && especialCharacters.IsMatch(password);
    }
}
