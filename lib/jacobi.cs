using static System.Math;

public static class jacobi{
	public static void timesJ(matrix A, int p, int q, double theta){
		double c = Cos(theta), s = Sin(theta);
		for(int i = 0; i < A.size1; i++){
			double Aip = A[i,p], Aiq = A[i,q];
			A[i,p] = c*Aip - s*Aiq;
			A[i,q] = c*Aiq + s*Aip;
		}
	}//timesJ
	
	public static void Jtimes(matrix A, int p, int q, double theta){
        double c = Cos(theta), s = Sin(theta);
        for(int i = 0; i < A.size2; i++){
			double Api = A[p,i], Aqi = A[q,i];
            A[p,i] = c*Api + s*Aqi;
            A[q,i] = c*Aqi - s*Api;
        }
	}//Jtimes

	public static void Gtimes(matrix A, int p, int q, double phi){
        double c = Cos(phi), s = Sin(phi);
        for(int i = 0; i < A.size2; i++){
			double Api = A[p,i], Aqi = A[q,i];
            A[p,i] = c*Api - s*Aqi;
            A[q,i] = c*Aqi + s*Api;
        }
	}//Gtimes

	public static void timesG(matrix A, int p, int q, double phi){
		double c = Cos(phi), s = Sin(phi);
		for(int i = 0; i < A.size1; i++){
			double Aip = A[i,p], Aiq = A[i,q];
			A[i,p] = c*Aip + s*Aiq;
			A[i,q] = c*Aiq - s*Aip;
		}
	}//timesG
	 
	public static (vector, matrix) cyclic(matrix M){
		matrix A = M.copy(), V = matrix.id(A.size1);	
		vector w = new vector(A.size1);
		bool changed;
		do{
			changed = false; //assume succesful diagonalization until proven otherwise
			for(int p = 0; p < A.size1-1; p++) //loop over upper triangle part of matrix to do rotation
			for(int q = p+1; q < A.size2; q++){
                double theta = 0.5*Atan2(2*A[p,q], A[q,q] - A[p,p]); //find theta
				double c = Cos(theta), s = Sin(theta);
				double new_App = c*c*A[p,p] - 2*s*c*A[p,q] + s*s*A[q,q]; //find new diagonal elements
				double new_Aqq = c*c*A[q,q] + 2*s*c*A[p,q] + s*s*A[p,p];
				if(new_App != A[p,p] || new_Aqq != A[q,q]){
                    timesJ(A, p, q, theta);
                    Jtimes(A, p ,q, -theta); //D <- J^T*D*J
                    timesJ(V, p, q, theta); //V <- VJ
					changed = true; //proven otherwise
				} 
			}
		}while(changed);
		for(int i = 0; i < w.size; i++)w[i] = A[i,i]; //collect the eigenvalues as the diagonal elements of D
		return (w, V);
	}//cyclic

	public static (vector, matrix, matrix, matrix) cyclic2svd(matrix M){
		matrix A = M.copy(), V = matrix.id(A.size1), U = matrix.id(A.size1);	
		vector w = new vector(A.size1);
		bool changed;
		do{
			changed = false; //assume succesful symmetrization of offdiagonal elements until proven otherwise
			for(int p = 0; p < A.size1; p++) //loop over upper triangle part of matrix to do rotation
			for(int q = p+1; q < A.size2; q++){
				double phi = Atan2(A[p,q]-A[q,p], A[p,p] + A[q,q]);  //find phi
				double cg = Cos(phi), sg = Sin(phi);
				double new_Apq = cg*A[p,q] - sg*A[q,q] ; //find new offdiagonal elements
				double new_Aqp = sg*A[p,p] + cg*A[q,p];
				if(new_Apq != new_Aqp ){
                    Gtimes(A, p ,q,  phi); //A <- G^T*A
                    timesG(U, p, q, - phi); //U <- U*G
					double theta = 0.5*Atan2(2*A[p,q], A[q,q] - A[p,p]); //find theta
					double c = Cos(theta), s = Sin(theta);
					double new_App = c*c*A[p,p] - 2*s*c*A[p,q] + s*s*A[q,q]; //find new diagonal elements
					double new_Aqq = c*c*A[q,q] + 2*s*c*A[p,q] + s*s*A[p,p];
					if(new_App != A[p,p] || new_Aqq != A[q,q]){
                        timesJ(A, p, q, theta);
                        Jtimes(A, p ,q, -theta); //G*A <- J^T*G^T*A*J
                        timesJ(V, p, q, theta); //V <- VJ
						timesJ(U, p, q, theta); //U*G <- U*G*J 
					}
					changed = true; //proven otherwise
				} 
			}
		}while(changed);
		for(int i = 0; i < w.size; i++)w[i] = A[i,i]; //collect the singular values as the diagonal elements of A
		return (w, V, U, A);
	}//cyclic2svd
	
	public static (vector, matrix) cyclic_opt(matrix A){
		int n = A.size1;
		matrix V = matrix.id(n);
        vector w = new vector(n); 		//vector of diagonal elements of A
		for(int i = 0; i < n; i++)w[i] = A[i,i];
        bool changed;
        do{
        	changed = false; //assume succesful diagonalization until proven otherwise
            for(int p = 0; p < n; p++) //loop over upper triangle part of matrix to do rotation
            for(int q = p+1; q < n; q++){
                double theta = 0.5*Atan2(2*A[p,q], w[q] - w[p]); //find theta
                double c = Cos(theta), s = Sin(theta);
                double new_App = c*c*w[p] - 2*s*c*A[p,q] + s*s*w[q]; //find new diagonal elements
                double new_Aqq = c*c*w[q] + 2*s*c*A[p,q] + s*s*w[p];
                if(new_App != w[p] || new_Aqq != w[q]){
					changed = true;
					timesJ(V, p, q, theta); 			//V <- VJ
					A[p,q] = s*c*(w[p] - w[q]) + (c*c - s*s)*A[p,q]; //update cross point
					w[p] = new_App; w[q] = new_Aqq; 		//update diagonal
					for(int i = 0; i < n; i++){
						if(i!=q && i!=p){
							int Mqi = Max(q,i), mqi = Min(q,i), Mpi = Max(p,i), mpi = Min(p,i); 
							double Api = A[mpi, Mpi], Aqi = A[mqi,Mqi]; //set old data 
							A[mpi,Mpi] = c*Api - s*Aqi;			//update remaining data
							A[mqi,Mqi] = s*Api + c*Aqi;
						}
					}
				}
			}
		}while(changed);
		for(int i = 0; i < n; i++)
		for(int j = i+1; j < n; j++)A[i,j] = A[j,i];
        return (w, V);
	}//cyclic_opt

	
	public static matrix svd2_pseudoinv(matrix M){
		(vector w, matrix V, matrix U, matrix S) = jacobi.cyclic2svd(M);
		for(int i = 0; i < S.size2; i++){
			S[i,i] = 1.0/S[i,i];
		}
		matrix UT = U.transpose();
		matrix Mpinv = V*S*UT;
		return (Mpinv);
	}//2svd_pseudoinv

	public static vector svd2_lsfit(System.Func<double,double>[] fs, vector x, vector y , vector dy){
        int n=x.size , m=fs.Length;
        var A = new matrix(n,m);
        var b = new vector(n);
        for (int i=0 ; i<n; i++){
            b[i] = y[i]/dy[i];
            for (int j=0; j<m ;j++){
                A[i,j] = fs[j](x[i])/dy[i];
            }
        }
		(matrix Q, matrix R) = qrgs.decomp(A);
		matrix Apinv = svd2_pseudoinv(R) * Q.transpose();
        var c = Apinv*b;
        return (c);
    }//lsfit

}//jacobi