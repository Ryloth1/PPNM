using System;
using static System.Math;
using System.Runtime.CompilerServices;

public static class QRGS{
        
    static void backsub(matrix U, vector c){
        for(int i=c.size-1; i>=0; i--){
            double sum=0;
            for(int k=i+1; k<c.size; k++)sum+=U[i,k]*c[k];
                c[i]=(c[i]-sum)/U[i,i]; 
        }
    }

    public static (matrix,matrix) decomp(matrix A){
        matrix Q=A.copy();
        matrix R=new matrix(A.size2,A.size2);    /* orthogonalize Q and fill-in R */
        for(int i=0; i<A.size2; i++){
            R[i,i]=Q[i].norm( ); /* Q[i] points to the i−th columb */
            Q[i]/=R[i,i] ;
            for(int j=i+1; j<A.size2; j++){
                R[i,j]=Q[i].dot(Q[j]) ;
                Q[j]-=Q[i]*R[i,j]; 
            }
        }
        return (Q,R);
    }
    public static vector solve(matrix Q, matrix R, vector b){
        vector y = Q.transpose() * b;
        backsub(R,y);
        return y;
    }
    public static double det(matrix R){
        double d = 0;
        for(int i=0; i<R.size1; i++){
            d*=R[i,i];
        }
        return d;
    }

    public static matrix inverse(matrix A){
        vector e = new vector(A.size2);
        matrix B = new matrix(A.size1);
        (matrix Q,matrix R) = decomp(A);
        for(int i=0; i<A.size1; i++){
		    e[i]=1;
            B[i] = solve(Q,R,e);
	    	e[i]=0;
        }
        return B;


    }
}
