package com.hyron.caitianci;




public class TestJava02 {
    public static void main(String[] args) {
        String str1 = "1";
        String str2 = ""+1;
        char ch1 = '1';
        String str3 = new String("1");
        System.out.println(ch1);
        System.out.println(str1.hashCode());
        System.out.println(str2.hashCode());
        System.out.println(str3.hashCode());
        System.out.println(str2.equals(str3));
    }
}
