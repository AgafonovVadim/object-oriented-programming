namespace Lab5.Application.Models.Transactions;

public record Transaction(long Id, long UserId, TransactioinType Type, int Amount);