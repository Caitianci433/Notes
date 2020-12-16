package com.hyron.caitianci;

import java.io.*;

public class TestIO01 {
    public static void main(String[] args) throws IOException{
        PrintWriter out = null;
        BufferedReader br = null;
        try{
            System.out.println("请输入:");
            out = new PrintWriter(System.out, true);
            br = new BufferedReader(new InputStreamReader(System.in));
            String line = null;
            while ((line = br.readLine()) != null) {
                if (line.equals("exit")) {
                    System.exit(1);
                }
                out.println(line);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }finally{
            out.close();
            br.close();
        }
    }
}
