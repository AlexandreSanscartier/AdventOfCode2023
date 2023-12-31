﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.ExtensionMethods
{
    public static class ListExtensions
    {
        public static int Multiply(this List<int> list)
        {
            var product = 1;
            foreach(var item in list)
            {
                product *= item;
            }
            return product;
        }

        public static long Multiply(this List<long> list)
        {
            var product = 1l;
            foreach (var item in list)
            {
                product *= item;
            }
            return product;
        }

        public static void Populate<T>(this T[] arr, T value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = value;
            }
        }
    }
}
