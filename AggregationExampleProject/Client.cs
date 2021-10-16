using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace Aggregation
{
    public class Client : IComparable
    {
        private readonly Deposit[] deposits;

        public Client()
        {
            deposits = new Deposit[10];
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Client otherClient = obj as Client;
            if (otherClient != null)
            {
                if (TotalIncome() > otherClient.TotalIncome()) return 1;
                else if (TotalIncome() < otherClient.TotalIncome()) return -1;
                else
                    return 0;
            }
            else
                throw new ArgumentException("Object is not a client");
        }

        public decimal TotalIncome()
        {
            decimal sum = 0m;
            for (int i = 0; i < deposits.Length; i++)
            {
                if (deposits[i] != null)
                {
                    sum += deposits[i].Income();
                }
            }

            return sum;
        }

        public decimal MaxIncome()
        {
            decimal max = 0;

            for (int i = 0; i < deposits.Length; i++)
            {
                if (deposits[i] != null && deposits[i].Income() > max)
                {
                    max = deposits[i].Income();
                }
            }

            return max;
        }

        public decimal GetIncomeByNumber(int number)
        {
            for (int i = 0; i < deposits.Length; i++)
            {
                if (deposits[i] == null)
                {
                    return 0;
                }
                else if (deposits[i].Income() != number)
                {
                    return deposits[i + 1].Income();
                }
                else
                {
                    return deposits[i].Income();
                }
            }

            throw new InvalidOperationException();
        }

        public bool AddDeposit(Deposit deposit)
        {
            bool answear = false;
            for (int i = 0; i < deposits.Length; i++)
            {
                if (deposits[i] == null)
                {
                    deposits[i] = deposit;
                    answear = true;
                    break;
                }
            }

            return answear;
        }
    }
}