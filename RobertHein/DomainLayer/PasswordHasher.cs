namespace Models.Managers;

public static class PasswordHasher
{
    private const string Pepper = "rOck375uR93RY";

    private static string GetRandomSalt()
    {
        return BCrypt.Net.BCrypt.GenerateSalt(12);
    }

    public static string HashPassword(string password)
    {
        string passWPepper = password + Pepper;
        return BCrypt.Net.BCrypt.HashPassword(passWPepper, GetRandomSalt());
    }

    public static bool ValidatePassword(string password, string correctHash)
    {

        string passWPepper = password + Pepper;
        return BCrypt.Net.BCrypt.Verify(passWPepper, correctHash);

    }
}