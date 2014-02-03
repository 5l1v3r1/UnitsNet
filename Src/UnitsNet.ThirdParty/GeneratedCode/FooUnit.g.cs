// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/SIUnits
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using UnitsNet.ThirdParty.Extensions;
using System;

// ReSharper disable once CheckNamespace
namespace UnitsNet.ThirdParty
{
    /// <summary>
    /// Example unit to illustrate adding third party units to Units.NET.
    /// </summary>
    public partial struct Foo : IComparable, IComparable<Foo>
    {
        /// <summary>
        /// Base unit of Foo.
        /// </summary>
        public readonly double Foos;

        public Foo(double foos) : this()
        {
            Foos = foos;
        }

        #region Properties

        /// <summary>
        /// Get Foo in FooPlusTwos.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in FooPlusTwos and y is value in base unit Foos.</remarks>
        public double FooPlusTwos
        {            
            get { return (Foos - 2) / 1; }
        }

        /// <summary>
        /// Get Foo in FoosQuadrupled.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in FoosQuadrupled and y is value in base unit Foos.</remarks>
        public double FoosQuadrupled
        { 
            get { return Foos / 4; }
        }

        /// <summary>
        /// Get Foo in TwiceThanFoos.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in TwiceThanFoos and y is value in base unit Foos.</remarks>
        public double TwiceThanFoos
        { 
            get { return Foos / 2; }
        }

        #endregion

        #region Static 

        public static Foo Zero
        {
            get { return new Foo(); }
        }
        
        /// <summary>
        /// Get Foo from Foos.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Foos and y is value in base unit Foos.</remarks>
        public static Foo FromFoos(double foos)
        { 
            return new Foo(1 * foos);
        }

        /// <summary>
        /// Get Foo from FooPlusTwos.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in FooPlusTwos and y is value in base unit Foos.</remarks>
        public static Foo FromFooPlusTwos(double fooplustwos)
        {            
            return new Foo(1 * fooplustwos + 2);
        }

        /// <summary>
        /// Get Foo from FoosQuadrupled.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in FoosQuadrupled and y is value in base unit Foos.</remarks>
        public static Foo FromFoosQuadrupled(double foosquadrupled)
        { 
            return new Foo(4 * foosquadrupled);
        }

        /// <summary>
        /// Get Foo from TwiceThanFoos.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in TwiceThanFoos and y is value in base unit Foos.</remarks>
        public static Foo FromTwiceThanFoos(double twicethanfoos)
        { 
            return new Foo(2 * twicethanfoos);
        }

        #endregion

        #region Arithmetic Operators

        public static Foo operator -(Foo right)
        {
            return new Foo(-right.Foos);
        }

        public static Foo operator +(Foo left, Foo right)
        {
            return new Foo(left.Foos + right.Foos);
        }

        public static Foo operator -(Foo left, Foo right)
        {
            return new Foo(left.Foos - right.Foos);
        }

        public static Foo operator *(double left, Foo right)
        {
            return new Foo(left*right.Foos);
        }

        public static Foo operator *(Foo left, double right)
        {
            return new Foo(left.Foos*right);
        }

        public static Foo operator /(Foo left, double right)
        {
            return new Foo(left.Foos/right);
        }

        public static double operator /(Foo left, Foo right)
        {
            return left.Foos/right.Foos;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Foo)) throw new ArgumentException("Expected type Foo.", "obj");
            return CompareTo((Foo) obj);
        }

        public int CompareTo(Foo other)
        {
            return Foos.CompareTo(other.Foos);
        }

        public static bool operator <=(Foo left, Foo right)
        {
            return left.Foos <= right.Foos;
        }

        public static bool operator >=(Foo left, Foo right)
        {
            return left.Foos >= right.Foos;
        }

        public static bool operator <(Foo left, Foo right)
        {
            return left.Foos < right.Foos;
        }

        public static bool operator >(Foo left, Foo right)
        {
            return left.Foos > right.Foos;
        }

        public static bool operator ==(Foo left, Foo right)
        {
            return left.Foos == right.Foos;
        }

        public static bool operator !=(Foo left, Foo right)
        {
            return left.Foos != right.Foos;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Foos.Equals(((Foo) obj).Foos);
        }

        public override int GetHashCode()
        {
            return Foos.GetHashCode();
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0:0.##} {1}", Foos, UnitSystem.Create().GetDefaultAbbreviation(FooUnit.Foo));
        }
    }
} 
