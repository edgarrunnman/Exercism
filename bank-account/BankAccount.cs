using System;
using System.Threading.Tasks;

public class BankAccount
{
    private bool _aktivStatus { get; set; } = false;
    private decimal _balance = 0;
    private object _lock = new object();
    public void Open()
    {
        this._aktivStatus = true;
    }

    public void Close()
    {
        this._aktivStatus = false;
    }

    public decimal Balance
    {
        get 
        {
            if (_aktivStatus)
            return _balance;
            throw new InvalidOperationException();
        }
    }

    public void UpdateBalance(decimal change)
    {
        lock (_lock)
        {
             _balance += change;
        }
    }
}
