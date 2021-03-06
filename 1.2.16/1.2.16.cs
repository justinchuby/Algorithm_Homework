﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2._16
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input numerator 1");
            int numer1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("input denominator 1");
            int denom1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("input numerator 2");
            int numer2 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("input denominator 2");
            int denom2 = Int32.Parse(Console.ReadLine());
            // Does not check for exceptions.

            Rational x = new Rational(numer1, denom1);
            Rational y = new Rational(numer2, denom2);

            Console.WriteLine($"x: {x}");
            Console.WriteLine($"y: {y}");
            Console.WriteLine($"equals: {x.Equals(y)}");
            Console.WriteLine($"==: {x == y}");
            Console.WriteLine($"!=: {x != y}");
            Console.WriteLine($"plus: {x.Plus(y)}");
            Console.WriteLine($"+: {x + y}");
            Console.WriteLine($"minus: {x.Minus(y)}");
            Console.WriteLine($"-: {x - y}");
            Console.WriteLine($"times: {x.Times(y)}");
            Console.WriteLine($"*: {x * y}");
            Console.WriteLine($"devides: {x.Devides(y)}");
            Console.WriteLine($"/: {x / y}");
            Console.ReadLine();




        }
    }
    public class Rational
    {
        private int numerator;
        private int denominator;
        public Rational(int _numer, int _denom)
        {
            if (_denom == 0)
            {
                throw new DivideByZeroException();
            }
            numerator = _numer;
            denominator = _denom;
            Reduce();
            // Done: Avoid "0"
        }

        public Rational Plus(Rational _b)
        {
            int tempn, tempd;
            tempn = _b.numerator;
            tempd = _b.denominator;
            tempn = numerator * tempd + tempn * denominator;
            tempd = denominator * tempd;
            Rational Rationaltemp = new Rational(tempn, tempd);

            return Rationaltemp ;
        }

        public static Rational operator +(Rational _a, Rational _b)
        {
            int tempn, tempd;
            tempn = _a.numerator * _b.denominator + _b.numerator * _a.denominator;
            tempd = _a.denominator * _b.denominator;
            Rational Rationaltemp = new Rational(tempn, tempd);

            return Rationaltemp;
        }

        public Rational Minus(Rational _b)
        {
            int tempn, tempd;
            tempn = _b.numerator;
            tempd = _b.denominator;
            tempn = numerator * tempd - tempn * denominator;
            tempd = denominator * tempd;
            Rational Rationaltemp = new Rational(tempn, tempd);

            return Rationaltemp;
        }

        public static Rational operator -(Rational _a, Rational _b)
        {
            int tempn, tempd;
            tempn = _a.numerator * _b.denominator - _b.numerator * _a.denominator;
            tempd = _a.denominator * _b.denominator;
            Rational Rationaltemp = new Rational(tempn, tempd);

            return Rationaltemp;
        }

        public Rational Times(Rational _b)
        {
            int tempn, tempd;
            tempn = _b.numerator;
            tempd = _b.denominator;
            tempn = numerator * tempn;
            tempd = denominator * tempd;
            Rational Rationaltemp = new Rational(tempn, tempd);

            return Rationaltemp;
        }

        public static Rational operator *(Rational _a, Rational _b)
        {
            int tempn, tempd;
            tempn = _a.numerator * _b.numerator;
            tempd = _a.denominator * _b.denominator;
            Rational Rationaltemp = new Rational(tempn, tempd);

            return Rationaltemp;
        }

        public Rational Devides(Rational _b)
        {
            int bn, bd, tempn, tempd;
            bn = _b.numerator;
            bd = _b.denominator;
            // 已修正变量错误
            tempn = numerator * bd;
            tempd = denominator * bn;
            Rational Rationaltemp = new Rational(tempn, tempd);

            return Rationaltemp;
        }

        public static Rational operator /(Rational _a, Rational _b)
        {
            int tempn, tempd;
            tempn = _a.numerator * _b.denominator;
            tempd = _a.denominator * _b.numerator;
            Rational Rationaltemp = new Rational(tempn, tempd);

            return Rationaltemp;
        }

        public Boolean Equals(Rational that)
        {
            if (this.numerator == 0 && that.numerator == 0)
            { return true; }
            Reduce();
            if ((this.numerator == that.numerator) && (this.denominator == that.denominator))
            { return true; }
            else
            { return false; }
        }

        public static Boolean operator ==(Rational _a, Rational _b)
        {
            if (_a.numerator == 0 && _b.numerator == 0)
            { return true; }
            if ((_a.numerator == _b.numerator) && (_a.denominator == _b.denominator))
            { return true; }
            else
            { return false; }

        }

        public static Boolean operator !=(Rational _a, Rational _b)
        {
            if (_a.numerator == 0 && _b.numerator == 0)
            { return false; }
            if ((_a.numerator == _b.numerator) && (_a.denominator == _b.denominator))
            { return false; }
            else
            { return true; }
        }

        public override string ToString()
        {
            return numerator.ToString() + " / " + denominator.ToString();
        }
        private static int gcd(int _a, int _b)
        {
            int a = _a;
            int b = _b;

            if (a == 0)
            {
                return b;
            }
            else
            {
                int t;
                while (b != 0)
                {
                    t = b;
                    b = a % b;
                    a = t;
                }
                return a;
            }
        }
        
        private void Reduce()
        {
            int q = gcd(numerator, denominator);
            numerator /= q;
            denominator /= q;
        }


    }
}
