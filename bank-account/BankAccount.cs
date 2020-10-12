using System;
using System.Threading.Tasks;

public class BankAccount
{
    private bool _aktivStatus { get; set; } = false;
    private decimal _balance = 0;
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
        _balance = _balance + change;
    }
}
