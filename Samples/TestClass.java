package Samples;
public class TestClass {
    public static void main(String[] args) {
        
        // Checks None checks in Java code
        // Risky: Null assignment without check
        String name = null;

    
        // Safe: Null check before use with `==`
        if (name == null){
            System.out.println("Name is null");
        }

        // Safe: Null check before use with `!=`
        String surname = "letageng";
        if (surname != null) { // defensive programming 
            System.out.println("Surname is not null");
        }
    }
}