using static System.Console;

public class main{
	public static void Main(string[] args){
		

		//Exercise A
		
        System.Console.WriteLine("Exercise A");
        System.Console.WriteLine("Test Eigenvalue decomposition");
		int n = 3;

        foreach(var arg in args){
		var words=arg.Split(':');
		if(words[0]=="-size1")n=int.Parse(words[1]);
	    }//take n from input


		System.Console.Error.WriteLine($"n={n}");
		matrix A = new matrix(n);
		System.Random random = new System.Random();
		for(int i = 0; i < n; i++)
		for(int j = i; j < n; j++){
			A[i,j] = random.NextDouble();
			A[j,i] = A[i,j];
		}
		A.print("A =");
		(vector w, matrix V) = jacobi.cyclic(A);
		(vector w_opt, matrix V_opt) = jacobi.cyclic_opt(A);
		w.print("EigenValues: ");
		w_opt.print("Eigenvalues using opt:");
		V.print("Eigenvectors = ");
		V_opt.print("Eigenvectors using opt = ");
		matrix D = matrix.diag(w);
		matrix VT = V.transpose();
		matrix VTAV = VT*A*V;
		matrix VDVT = V*D*VT;
		matrix VTV = VT*V;
        matrix VVT = V*VT;
		System.Console.WriteLine($"V^T*A*V = D = {VTAV.approx(D)} ");
        System.Console.WriteLine($"V*D*VT = A = {VDVT.approx(A)} ");
        System.Console.WriteLine($"V*VT = 1 = {VTV.approx(matrix.id(n))} ");
        System.Console.WriteLine($"VT*V = 1 = {VVT.approx(matrix.id(n))} ");
        
	}//Main
}//main