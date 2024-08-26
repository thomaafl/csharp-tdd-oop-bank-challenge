﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main.Acounts
{
    public abstract class Account
    {
        public decimal Balance { 
            get
            { 
                return Transactions
                    .Where(x => x.type == TransactionType.CREDIT)
                    .Sum(x => x.amount) - Transactions
                    .Where(x => x.type == TransactionType.DEBIT)
                    .Sum(x => x.amount);
            }
        }

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public Branch yourBranch { get; set; }

        public void Deposit(decimal amount)
        {
            if (amount >= 0)
            {
                Transactions.Add(new Transaction { amount = amount, date = DateTime.Now, type = TransactionType.CREDIT});
            }
            else
            {
                Console.WriteLine("Cant deposit a value like that");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0 || amount > this.Balance)
            {
                Console.WriteLine("Cant withdraw a value like that or you do not have enough money in your account...");
            }
            else
            {
                Transactions.Add(new Transaction { amount = amount, date = DateTime.Now, type = TransactionType.DEBIT });

            }
        }
    }
}
