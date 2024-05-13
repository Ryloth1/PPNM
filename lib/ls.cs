public static class LS{
    public static (vector,matrix) lsfit(System.Func<double,double>[] fs, vector x, vector y , vector dy){
        int n=x.size , m=fs.Length;
        var A = new matrix(n,m);
        var b = new vector(n);
        for (int i=0 ; i<n; i++){
            b[i] = y[i]/dy[i];
            for (int j=0; j<m ;j++){
                A[i,j] = fs[j](x[i])/dy[i];
            }
        }
        (matrix Q,matrix R) = QRGS.decomp(A);
        var c = QRGS.solve(Q,R,b);
        vector e = new vector(R.size2);
        matrix Rinv = new matrix(R.size1);
        for(int i=0; i<A.size1; i++){
		    e[i]=1;
            QRGS.backsub(R,e);
            Rinv [i] = e;
    	    e[i]=0;
        }
        var S = Rinv * Rinv.transpose();
        return (c,S);
    }
    

}