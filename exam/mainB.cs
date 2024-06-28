using static System.Console;
using System;
using static System.Math;

public class main{
	public static int Main(string[] args){

        //Exercise B - pseudo inverse and least square fit using SVD
		System.Console.WriteLine("");
		System.Console.WriteLine("Exercise B");
        System.Console.WriteLine("Calculation of Pseudo inverse  and solving least square fit with two sided jacobi SVD");

        int n = 3;
		matrix B = matrix.newrandmatrix(n);
		B.print("B =");
		(vector w, matrix V, matrix U, matrix S) = jacobi.cyclic2svd(B);
		S.print("S=");
		matrix Sinv = S;
		for(int i = 0; i < Sinv.size1; i++)
		for(int j = 0; j < Sinv.size2; j++){
			Sinv[i,j] = 1/Sinv[i,j];
			Sinv[j,i] = Sinv[i,j];
		}
		Sinv.print("Sinv");
		matrix SinvS = Sinv * S;
		SinvS.print("Sinv * S=");
		System.Console.WriteLine($" Sinv*S = 1 = {SinvS.approx(matrix.id(n))} ");
		matrix Bpinv = jacobi.svd2_pseudoinv(B);
		matrix BBpinvB = B*Bpinv*B;
		Bpinv.print("Bpinv =");
		System.Console.WriteLine($" B*Bpinv*B = B = {BBpinvB.approx(B)} ");
		System.Console.WriteLine($"");
		System.Console.WriteLine($"I do not know why Sinv*S does not give me 1 with the matrix multiplication operation.");
		System.Console.WriteLine($"When i do it manually or with another program i get 1 and B*Bpinv*B is also B ");


        //ls with SVD
		//Read the data from file
		string infile = null;
		foreach(var arg in args){
			var words = arg.Split(':');
			if(words[0]=="-input")infile=words[1];
		}
		if(infile==null){Error.WriteLine("Wrong filename"); 
        return 1;
        }//wrong file
		genlist<double> _t = new genlist<double>(), _y = new genlist<double>(), _dy = new genlist<double>();
		var instream = new System.IO.StreamReader(infile);
		for(string line = instream.ReadLine();line!=null;line=instream.ReadLine()){
			var nums = line.Split(' ');
			_t.add(double.Parse(nums[0]));
            _y.add(double.Parse(nums[1]));
            _dy.add(double.Parse(nums[2]));
		}
		vector t = _t.get_data();
		vector y = _y.get_data();
		vector dy = _dy.get_data();

		vector lny = new vector(9), dlny = new vector(9);
		for(int i = 0; i < 9; i++){
			lny[i] = Log(y[i]);
			dlny[i] = dy[i]/y[i];
        }
        Func<double,double>[] fs = new Func<double,double>[] { z => 1.0, z => -z};

        int l=t.size , m=fs.Length;
        var A = new matrix(l,m);
        var b = new vector(l);
        for (int i=0 ; i<l; i++){
            b[i] = y[i]/dy[i];
            for (int j=0; j<m ;j++){
                A[i,j] = fs[j](t[i])/dy[i];
            }
        }
		vector c = jacobi.svd2_lsfit(fs, t, lny, dlny);
		c.print("c:");
		double tau = Log(2)/c[1];
		WriteLine($"a = {Exp(c[0])}");
		WriteLine($"tau = {tau} pm days, table value: 3.6313(14) days");
        WriteLine($"As can be easily seen, this is the same result as the ls fit in homework 11");
		return 0;

	}//Main
}//main