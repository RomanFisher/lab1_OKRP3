using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Globalization;
using System.Collections;

namespace lab1
{
    public static class Sort
    {
        public static Address[] bubble(Address[] address, MethodInfo method)
        {
            bool needSort;
            Address tempAddress;

            do
            {
                needSort = false;
                for (int i = 0; i < address.Length - 1; i++)
                    if (Comparer.DefaultInvariant.Compare(method.Invoke(address[i], null), method.Invoke(address[i + 1], null)) == 1)
                    {
                        tempAddress = address[i];
                        address[i] = address[i + 1];
                        address[i + 1] = tempAddress;
                        needSort = true;
                    }
            } while (needSort);
            return address;
        }
        public static Address[] mix(Address[] address, MethodInfo method)
        {
            bool needSort;
            Address tempAddress;

            do
            {
                needSort = false;
                for (int i = 0; i < address.Length - 1; i++)
                    if (Comparer.DefaultInvariant.Compare(method.Invoke(address[i], null), method.Invoke(address[i + 1], null)) == 1)
                    {
                        tempAddress = address[i];
                        address[i] = address[i + 1];
                        address[i + 1] = tempAddress;
                        needSort = true;
                    }
                for (int i = address.Length - 1; i > 0; i--)
                    if (Comparer.DefaultInvariant.Compare(method.Invoke(address[i], null), method.Invoke(address[i - 1], null)) == -1)
                    {
                        tempAddress = address[i];
                        address[i] = address[i - 1];
                        address[i - 1] = tempAddress;
                        needSort = true;
                    }
            } while (needSort);
            return address;
        }
        public static Address[] MinimumElement(Address[] address, MethodInfo method)
        {
            int min;
            Address tempAddress;

            for (int i = 0; i < address.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < address.Length; j++)
                    if (Comparer.DefaultInvariant.Compare(method.Invoke(address[min], null), method.Invoke(address[j], null)) == 1)
                        min = j;
                if (min != i)
                {
                    tempAddress = address[i];
                    address[i] = address[min];
                    address[min] = tempAddress;
                }
            }
            return address;
        }
        public static Address[] insert(Address[] address, MethodInfo method)
        {
            int j;
            Address tempAddress;
            for (int i = 1; i < address.Length; i++)
            {
                tempAddress = address[i];
                j = i;
                while (j > 0 && Comparer.DefaultInvariant.Compare(method.Invoke(address[j - 1], null), method.Invoke(tempAddress, null)) == 1)
                {
                    address[j] = address[j - 1];
                    j--;
                }
                address[j] = tempAddress;
            }
            return address;
        }
    }
}
