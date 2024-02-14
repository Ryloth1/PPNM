public class genlist<T>{
	public T[] data;
	public int size => data.Length; // property
	public T this[int i] => data[i]; // indexer
	public genlist(){ data = new T[0]; }
	public void add(T item){ /* add item to the list */
		T[] newdata = new T[size+1];
		System.Array.Copy(data,newdata,size);
		newdata[size]=item;
		data=newdata;
	}
    public void remove(int i){
        for (int x= i;x< data.Length - 1; x++){
            data[x] = data[x+1];
        //data[i] = 
        //System.Array.RemoveEmptyEntries
        }
        System.Array.Resize(ref data, data.Length -1);
    }
}
