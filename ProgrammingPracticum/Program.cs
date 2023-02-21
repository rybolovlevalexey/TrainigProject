using System;
using System.Collections.Generic;

namespace Арифметика_с_приоритетом_действий
{
    class Program
    {
        static void Main(string[] args)
        {
            string st = Console.ReadLine();
            List<char> stack = new List<char>();
            string number = null;
            string result = "";

            foreach (var elem in st)
            {
                if (elem == ' ')
                    continue;
                bool is_number = false;
                foreach (var numb in "1234567890")
                {
                    if (numb == elem)
                        is_number = true;
                }
                if (is_number)
                    number += elem;
                else
                {
                    if (!(number is null))
                    {
                        result += number;
                        result += " ";
                        number = null;
                    }
                    switch (elem)
                    {
                        case '(':
                            stack.Add(elem);
                            break;
                        case '+':
                            if (stack.Count > 0)
                            {
                                stack.Reverse();
                                while (stack[0] == '*' || stack[0] == '+' || stack[0] == '-')
                                {
                                    result += stack[0];
                                    result += " ";
                                    stack.RemoveAt(0);
                                }
                                stack.Reverse();
                            }
                            stack.Add(elem);
                            break;
                        case '-':
                            if (stack.Count > 0)
                            {
                                stack.Reverse();
                                while (stack[0] == '*' || stack[0] == '+' || stack[0] == '-')
                                {
                                    result += stack[0];
                                    result += " ";
                                    stack.RemoveAt(0);
                                }
                                stack.Reverse();
                            }
                            stack.Add(elem);
                            break;
                        case '*':
                            stack.Reverse();
                            while (stack[0] == '*')
                            {
                                result += stack[0];
                                result += " ";
                                stack.RemoveAt(0);
                            }
                            stack.Reverse();
                            stack.Add(elem);
                            break;
                        case ')':
                            int delete_cnt = 0;
                            stack.Reverse();
                            foreach (var deyst in stack)
                            {
                                if (deyst == '(')
                                    break;
                                result += deyst;
                                result += " ";
                                delete_cnt += 1;
                            }
                            for (int i = 0; i <= delete_cnt; i += 1)
                                stack.RemoveAt(0);
                            stack.Reverse();
                            break;
                    }
                }
            }
            if (!(number is null))
            {
                result += number;
                result += " ";
            }
            if (stack.Count > 0)
            {
                stack.Reverse();
                foreach (var deyst in stack)
                {
                    result += deyst;
                    result += " ";
                }
            }
            result = result[0..(result.Length - 1)];
            Console.WriteLine($"Постфиксная запись: {result}");

            string[] primer = result.Split();
            List<int> numbers_stack = new List<int>();
            foreach (string elem in primer)
            {
                if (elem == " ")
                    continue;
                bool flag_is_number = false;
                foreach (var numbs in "1234567890")
                {
                    
                    if (elem[0] == numbs)
                        flag_is_number = true;
                }
                if (flag_is_number)
                {
                    numbers_stack.Add(Convert.ToInt32(elem));
                } else
                {
                    int first = numbers_stack[numbers_stack.Count - 2];
                    int second = numbers_stack[numbers_stack.Count - 1];
                    numbers_stack.RemoveAt(numbers_stack.Count - 1);
                    numbers_stack.RemoveAt(numbers_stack.Count - 1);
                    int res = 0;
                    switch (elem)
                    {
                        case "+":
                            res = first + second;
                            numbers_stack.Add(res);
                            break;
                        case "-":
                            res = first - second;
                            numbers_stack.Add(res);
                            break;
                        case "*":
                            res = first * second;
                            numbers_stack.Add(res);
                            break;
                    }
                }
            }
            Console.WriteLine($"Ответ: {numbers_stack[0]}");
        }
    }
}
