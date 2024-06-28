using System;
using static System.Math;
using System.Runtime.CompilerServices;


class main{
    
    public static int Main(string[] args){
        
        /* Exercise A*/

        System.Console.WriteLine("Exercise A");
        System.Console.WriteLine("A.1 test decomp for tall matrix");

	int n=3,m=2;
	foreach(var arg in args){
		var words=arg.Split(':');
		if(words[0]=="-size1")n=int.Parse(words[1]);
		if(words[0]=="-size2")m=int.Parse(words[1]);
	}
        System.Console.Error.WriteLine($"n={n} m={m}");
        matrix A1 = matrix.newrandmatrix(n,m);
	    A1.print("A=");

        (matrix Q1,matrix R1) = qrgs.decomp(A1);
    
        //R1.print("R=");
        //Q1.print("Q=");
        matrix QtQ = Q1.transpose() * Q1;
        matrix M = Q1*R1;

        //QtQ.print("Q^TQ=");
        System.Console.WriteLine($"QtQ=1={QtQ.approx(matrix.id(Q1.size2))}");
        //M.print("QR=");
        System.Console.WriteLine($"A=QR={M.approx(A1)}");

        System.Console.WriteLine("A.2 test solve for square matrix");

        matrix A2 = matrix.newrandmatrix(n,n);
	    //A2.print("A=");

        vector b = vector.newrandvector(n);
        //b.print("b=");

        (matrix Q2,matrix R2) = qrgs.decomp(A2);
        
        vector y = qrgs.solve(Q2,R2,b);
        //y.print("y=");

        System.Console.WriteLine($"QRy=b={b.approx(Q2*R2*y)}");

        /*Exercise B*/

        System.Console.WriteLine("Exercise B");
        System.Console.WriteLine("B test inverse for square matrix");


        matrix A3 = matrix.newrandmatrix(n,n);
	    A3.print("A=");
        matrix A3inv = qrgs.inverse(A3);
        A3inv.print("A^-1=");
        matrix AAinv = A3 * A3inv;
        AAinv.print("AA^-1=");
        matrix AinvA = A3inv * A3;
        matrix I = matrix.id(A3.size1);
        System.Console.WriteLine($"AA^-1=1={AAinv.approx(I)}");
        System.Console.WriteLine($"A^-1A=1={AinvA.approx(I)}");


        



    

	return 0;
    }



}
