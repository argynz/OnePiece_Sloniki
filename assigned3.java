import java.util.Scanner;
import java.util.*;

public class assigned3 {
    static Scanner inp = new Scanner(System.in);                 
    static ArrayList<Integer> hp =new ArrayList<Integer>();

    public static void Sorter(int i){
        if(i < 0) return;
        int top = i; 
        int left = 2 * i + 1; 
        int right = 2 * i + 2;  

        if(left < hp.size() && hp.get(left) > hp.get(top))
            top = left;               
        else if (right < hp.size() && hp.get(right) > hp.get(top))
            top = right;
        if(top != i) {
            Collections.swap(hp, i, top);   
            Sorter(top); 
        }
        Sorter(i-1);
    }

    public static void Insertion(int n){
        if(n<1) return;
        hp.add(inp.nextInt());
        Sorter(hp.size() / 2 - 1);
        Insertion(n-1);
    }

    public static void delete(int n){
        if (hp.size()<1) {
            return;
        }else{
            Collections.swap(hp, 0, hp.size()-1);
            hp.remove(hp.size()-1);
            Sorter(hp.size() / 2 - 1);
            System.out.println(hp);
            delete(n);
        }
    }
    public static void main(String[] args) {
        int x = inp.nextInt();
        Insertion(x);
        System.out.println(hp);
        delete(x);
        inp.close();  
    }
}
