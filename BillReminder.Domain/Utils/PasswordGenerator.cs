
namespace BillReminder.Domain.Utils;

public static class PasswordGenerator
{
    static string alphaCaps = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    static string alphaLow = "abcdefghijklmnopqrstuvwxyz";
    static string numerics = "1234567890";
    static string special = "@#$-!";
    static Random r = new Random();

    public static string GenerateRandomPassword(int length = 8)
    {
        string allChars = alphaCaps + alphaLow + numerics + special;
        String generatedPassword = "";
        if (length < 4)
            throw new Exception("Number of characters should be greater than 4.");
        int lowerpass, upperpass, numpass, specialchar;
        string posarray = "0123456789";
        if (length < posarray.Length)
            posarray = posarray.Substring(0, length);
        lowerpass = getRandomPosition(ref posarray);
        upperpass = getRandomPosition(ref posarray);
        numpass = getRandomPosition(ref posarray);
        specialchar = getRandomPosition(ref posarray);


        for (int i = 0; i < length; i++)
        {
            if (i == lowerpass)
                generatedPassword += getRandomChar(alphaCaps);
            else if (i == upperpass)
                generatedPassword += getRandomChar(alphaLow);
            else if (i == numpass)
                generatedPassword += getRandomChar(numerics);
            else if (i == specialchar)
                generatedPassword += getRandomChar(special);
            else
                generatedPassword += getRandomChar(allChars);
        }
        return generatedPassword;
    }

    private static string getRandomChar(string fullString)
    {
        return fullString.ToCharArray()[(int)Math.Floor(r.NextDouble() * fullString.Length)].ToString();
    }

    private static int getRandomPosition(ref string posArray)
    {
        int pos;
        string randomChar = posArray.ToCharArray()[(int)Math.Floor(r.NextDouble() * posArray.Length)].ToString();
        pos = int.Parse(randomChar);
        posArray = posArray.Replace(randomChar, "");
        return pos;
    }
}
