using System;
using static System.Console;
using static System.Math;
using static cmath;

public class main{

    static int Main(){
	    var one = System.Numerics.Complex.One;
	    var J = System.Numerics.Complex.ImaginaryOne;

        WriteLine($"sqrt(-1) {sqrt((complex)(-1))} {System.Numerics.Complex.Sqrt(-1*one)}");
        WriteLine($"sqrt(I) {sqrt(I)} {System.Numerics.Complex.Sqrt(J)}");
        WriteLine($"e^I {exp(I)} {System.Numerics.Complex.Exp(J)}");
        WriteLine($"e^(I*PI) {exp(I*PI)} {System.Numerics.Complex.Exp(J*PI)}");
        WriteLine($"I^I {I.pow(I)} {System.Numerics.Complex.Pow(J,J)}");
        WriteLine($"ln(i) {log(I)} {System.Numerics.Complex.Log(J)}");
        WriteLine($"sin(I*PI) {sin(I*PI)} {System.Numerics.Complex.Sin(J*PI)}");


        return 0;
    }//Main
}//main
