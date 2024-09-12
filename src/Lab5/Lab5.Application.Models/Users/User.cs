namespace Lab5.Application.Models.Users;

public record User(long Id, string Username, UserRole UserRole, int AccountNumber, int PinCode);