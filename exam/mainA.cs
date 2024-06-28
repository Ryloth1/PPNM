using static System.Console;
using System;
using static System.Math;

public class main{
	public static void Main(string[] args){


		//Exercise A - two sided jacobi svd
        System.Console.WriteLine("Exercise A");
        System.Console.WriteLine("Test  Two sided Jacobi SVD");
		int n = 3;

        foreach(var arg in args){
		var words=arg.Split(':');
		if(words[0]=="-size1")n=int.Parse(words[1]);
	    }//take n from input


		System.Console.Error.WriteLine($"n={n}");
		matrix M = matrix.newrandmatrix(n);
		M.print("A =");
				
			
	
		(vector w, matrix V, matrix U, matrix S) = jacobi.cyclic2svd(M);
		//(vector w_opt, matrix V_opt) = jacobi.cyclic_opt(A);
        S.print("S =");
		w.print("singular values: ");
		//w_opt.print("singular values using opt:");
        //matrix S = matrix.diag(w);
		matrix VT = V.transpose();
        matrix UT = U.transpose();
        matrix USVT = U*S*VT;
        matrix UTU = UT*U;
		matrix VTV = VT*V;
        matrix VVT = V*VT;
        System.Console.WriteLine($"U*S*VT = A = {USVT.approx(M)} ");
        System.Console.WriteLine($"U^T*U = 1 = {UTU.approx(matrix.id(n))} ");
        System.Console.WriteLine($"V*VT = 1 = {VTV.approx(matrix.id(n))} ");
        System.Console.WriteLine($"VT*V = 1 = {VVT.approx(matrix.id(n))} ");


	}//Main
}//main