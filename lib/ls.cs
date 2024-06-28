public static class ls{
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
        (matrix Q,matrix R) = qrgs.decomp(A);
        var c = qrgs.solve(Q,R,b);
        matrix Rinv = qrgs.inverse(R);
        var S = Rinv * Rinv.transpose();
        return (c,S);
    }//lsfit
    

}//ls