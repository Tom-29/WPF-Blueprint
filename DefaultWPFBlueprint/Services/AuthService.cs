using System.Security.Cryptography;
using System.Text;
using DefaultWPFBlueprint.Models;
using DefaultWPFBlueprint.Persistence;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DefaultWPFBlueprint.Services;

public static class AuthService
{
    private static string HashPassword(string password)
    {
        return Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(password)));
    }

    public static User? AuthenticateUser(string username, string password)
    {
        using AppDbContext db = new();
        return db.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == HashPassword(password));
    }

    public static User? RegisterUser(string username, string password, out string errorMessage)
    {
        using AppDbContext db = new();
        if (db.Users.Any(u => u.Username == username))
        {
            errorMessage = "Benutzername existiert bereits.";
            return null;
        }

        User newUser = new User { Username = username, PasswordHash = HashPassword(password) };
        EntityEntry<User> savedUser = db.Users.Add(newUser);
        db.SaveChanges();

        errorMessage = string.Empty;
        return savedUser.Entity;
    }
}