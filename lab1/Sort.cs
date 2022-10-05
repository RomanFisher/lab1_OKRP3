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
            
            return address;
        }
        public static Address[] insert(Address[] address, MethodInfo method)
        {
           
            return address;
        }
    }
}
