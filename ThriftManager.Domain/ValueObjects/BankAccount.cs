﻿namespace ThriftManager.Domain.ValueObjects;

public record BankAccount
{
    public string AccountNo { get; }
    public string AccountName { get; }
    public string BVN { get; }
    public int BankId { get; }

    public BankAccount()
    {
        BankId = 0;
        AccountName = "";
        AccountNo = "";
        BVN = "";
    }

    public BankAccount(string accountNo, string accountName, string bvn, int bankId)
    {
        BankId = bankId;
        AccountName = accountName;
        AccountNo = accountNo;
        BVN = bvn;
    }

    public static BankAccount Default() => new();

    public static BankAccount Create(string accountNo, string accountName, string bvn, int bankId)
        => new(accountNo, accountName, bvn, bankId);
}
